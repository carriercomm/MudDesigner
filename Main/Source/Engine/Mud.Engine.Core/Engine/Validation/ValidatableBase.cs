﻿//-----------------------------------------------------------------------
// <copyright file="ValidatableBase.cs" company="Sully">
//     Copyright (c) Johnathon Sullinger. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
namespace Mud.Engine.Core.Engine.Validation
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// An implementation of IValidatable that provides a base class for validating instances with property attributes implementing IValidationRule.
    /// </summary>
    public class ValidatableBase : IValidatable
    {
        /// <summary>
        /// The property validation reflection cache
        /// </summary>
        private static readonly Dictionary<Type, Dictionary<PropertyInfo, IEnumerable<IValidationRule>>> PropertyValidationCache
            = new Dictionary<Type, Dictionary<PropertyInfo, IEnumerable<IValidationRule>>>();

        /// <summary>
        /// The ValidationMessages backing field.
        /// </summary>
        private Dictionary<string, ICollection<IMessage>> validationMessages;

        /// <summary>
        /// Initializes a new instance of the <see cref="ValidatableBase" /> class.
        /// </summary>
        public ValidatableBase()
        {
            this.validationMessages = new Dictionary<string, ICollection<IMessage>>();
            this.SetupValidation();
        }

        /// <summary>
        /// Occurs when the instances validation state has changed.
        /// </summary>
        public event EventHandler<ValidationChangedEventArgs> ValidationChanged;

        /// <summary>
        /// Adds a validation message to the instance.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="property">The property.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">property;You must supply a property name when adding a new validation message to this instance.</exception>
        public void AddValidationMessage(IMessage message, string property)
        {
            if (string.IsNullOrEmpty(property))
            {
                throw new ArgumentOutOfRangeException("property", "You must supply a property name when adding a new validation message to this instance.");
            }

            // If the key does not exist, then we create one.
            if (!this.validationMessages.ContainsKey(property))
            {
                this.validationMessages[property] = new List<IMessage>();
            }

            if (this.validationMessages[property].Any(msg => msg.Message.Equals(message.Message) || msg == message))
            {
                return;
            }

            this.validationMessages[property].Add(message);
        }

        /// <summary>
        /// Removes all of the instances validation messages.
        /// </summary>
        public void RemoveValidationMessages()
        {
            foreach (KeyValuePair<string, ICollection<IMessage>> pair in this.validationMessages)
            {
                pair.Value.Clear();

                // Publish our new validation collection for this property.
                this.OnValidationChanged(new ValidationChangedEventArgs(pair.Key, this.validationMessages[pair.Key]));
            }
        }

        /// <summary>
        /// Removes all of the instances validation messages for the given property.
        /// </summary>
        /// <param name="property">The property.</param>
        public void RemoveValidationMessages(string property)
        {
            if (!string.IsNullOrEmpty(property) && this.validationMessages.ContainsKey(property))
            {
                // Remove all validation messages for the property if a message isn't specified.
                this.validationMessages[property].Clear();
                this.OnValidationChanged(new ValidationChangedEventArgs(property, this.validationMessages[property]));
            }
        }

        /// <summary>
        /// Removes the given validation message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="property">The property.</param>
        public void RemoveValidationMessage(IMessage message, string property)
        {
            if (string.IsNullOrEmpty(property))
            {
                return;
            }

            if (!this.validationMessages.ContainsKey(property))
            {
                return;
            }

            if (this.validationMessages[property].Any(msg => msg == message || msg.Message.Equals(message.Message)))
            {
                // Remove the error from the key's collection.
                this.validationMessages[property].Remove(
                    this.validationMessages[property].FirstOrDefault(msg => msg == message || msg.Message.Equals(message.Message)));

                this.OnValidationChanged(new ValidationChangedEventArgs(property, this.validationMessages[property]));
            }
        }

        /// <summary>
        /// Determines whether this instance has validation messages for the specified property.
        /// </summary>
        /// <param name="property">The property.</param>
        /// <returns>
        /// Returns true if validation messages exist for the given property.
        /// </returns>
        public bool HasValidationMessages(string property = "")
        {
            if (string.IsNullOrEmpty(property) || !this.validationMessages.ContainsKey(property))
            {
                return this.validationMessages.Values.Any(collection => collection.Any());
            }

            return this.validationMessages.ContainsKey(property) &&
                this.validationMessages[property].Any();
        }

        /// <summary>
        /// Determines whether this instance has validation messages for the specified property, whose IMessage implementation matches the Type given.
        /// </summary>
        /// <param name="messageType">Type of the message.</param>
        /// <param name="property">The property.</param>
        /// <returns>
        /// Returns true if validation messages exist for the given property.
        /// </returns>
        public bool HasValidationMessages(Type messageType, string property = "")
        {
            if (string.IsNullOrEmpty(property) || !this.validationMessages.ContainsKey(property))
            {
                return this.validationMessages.Values.Any(collection => collection.Any(item => item.GetType() == messageType));
            }

            return this.validationMessages.ContainsKey(property) &&
                this.validationMessages[property].Any(collection => collection.GetType() == messageType);
        }

        /// <summary>
        /// Determines whether this instance has validation messages for the specified property, whose IMessage implementation matches the Type given.
        /// </summary>
        /// <typeparam name="TMessage">The type of the message.</typeparam>
        /// <param name="property">The property.</param>
        /// <returns>
        /// Returns true if validation messages exist for the given property.
        /// </returns>
        public bool HasValidationMessages<TMessage>(string property = "") where TMessage : IMessage, new()
        {
            if (string.IsNullOrEmpty(property) || !this.validationMessages.ContainsKey(property))
            {
                return this.validationMessages.Values.Any(collection => collection.Any(item => item is TMessage));
            }

            return this.validationMessages.ContainsKey(property) &&
                this.validationMessages[property].Any(message => message is TMessage);
        }

        /// <summary>
        /// Gets a key/value representation of this instances validation messages.
        /// </summary>
        /// <returns>
        /// Returns a key/value pair. The key represents the instances property names while the value holds a collection of validation messages for the property.
        /// </returns>
        public Dictionary<string, IEnumerable<IMessage>> GetValidationMessages()
        {
            var messages = new Dictionary<string, IEnumerable<IMessage>>();

            // We have to iterate over the collection in order to conver the messages collection
            // from a ICollection type to an IEnumerable type.
            foreach (KeyValuePair<string, ICollection<IMessage>> pair in this.validationMessages)
            {
                messages.Add(pair.Key, pair.Value);
            }

            return messages;
        }

        /// <summary>
        /// Gets the validation messages for the given property..
        /// </summary>
        /// <param name="property">The property.</param>
        /// <returns>
        /// Returns a collection of validation messages.
        /// </returns>
        public IEnumerable<IMessage> GetValidationMessages(string property)
        {
            if (this.validationMessages.ContainsKey(property))
            {
                return this.validationMessages[property].ToArray();
            }

            // If no validation messages exist, return an empty collection.
            return new Collection<IMessage>();
        }

        /// <summary>
        /// Performs validation on all of the instances properties that are eligible for validation.
        /// </summary>
        public virtual void ValidateAll()
        {
            this.RemoveValidationMessages();
            Dictionary<PropertyInfo, IEnumerable<IValidationRule>> cache = PropertyValidationCache[this.GetType()];

            foreach (KeyValuePair<PropertyInfo, IEnumerable<IValidationRule>> pair in cache)
            {
                foreach (IValidationRule rule in pair.Value)
                {
                    this.PerformValidation(rule, pair.Key);
                }

                // Publish our new validation collection for this property.
                this.OnValidationChanged(new ValidationChangedEventArgs(pair.Key.Name, this.validationMessages[pair.Key.Name]));
            }
        }

        /// <summary>
        /// Validates the specified property if the property is decorated with an IValidationRule attribute.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        public void ValidateProperty(string propertyName = "")
        {
            // If no property is provided, we assume we are to validate everything.
            if (string.IsNullOrEmpty(propertyName))
            {
                this.ValidateAll();
                return;
            }

            this.RemoveValidationMessages(propertyName);
            var cache = ValidatableBase.PropertyValidationCache[this.GetType()];
            PropertyInfo property = cache.Keys.FirstOrDefault(p => p.Name.Equals(propertyName));

            foreach (IValidationRule rule in cache[property])
            {
                this.PerformValidation(rule, property);
            }

            this.OnValidationChanged(new ValidationChangedEventArgs(propertyName, this.validationMessages[propertyName]));
        }

        /// <summary>
        /// Validates the specified property via the supplied method delegate.
        /// </summary>
        /// <param name="validationDelegate">The validation delegate.</param>
        /// <param name="failureMessage">The failure message.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="validationProxy">The validation proxy.</param>
        /// <returns>Returns an IMessage if validation was not successful, otherwise null is returned to indicate success.</returns>
        public IMessage ValidateProperty(Func<bool> validationDelegate, IMessage failureMessage, string propertyName, IValidatable validationProxy = null)
        {
            if (validationProxy != null)
            {
                return validationProxy.ValidateProperty(validationDelegate, failureMessage, propertyName);
            }

            bool passedValidation = validationDelegate();
            if (!passedValidation)
            {
                this.AddValidationMessage(failureMessage, propertyName);
            }
            else
            {
                this.RemoveValidationMessage(failureMessage, propertyName);
            }

            return !passedValidation ? failureMessage : null;
        }

        /// <summary>
        /// Refreshes the validation.
        /// </summary>
        /// <param name="property">The property.</param>
        public void RefreshValidation(string property)
        {
            if (!string.IsNullOrEmpty(property) && this.HasValidationMessages(property))
            {
                this.ValidateProperty(property);
            }
        }

        /// <summary>
        /// Performs the given validation rule for the specified property.
        /// </summary>
        /// <param name="rule">The rule.</param>
        /// <param name="property">The property.</param>
        /// <param name="validationProxy">A validation proxy can be specified.
        /// When supplied, the validation rule and any errors associated with it will be stored within the proxy object instead of this instance.</param>
        /// <exception cref="System.ArgumentNullException">
        /// PerformValidation requires a registered property to be specified.
        /// or
        /// PerformValidation requires a registered property to be specified.
        /// </exception>
        public void PerformValidation(IValidationRule rule, string property, IValidatable validationProxy = null)
        {
            PropertyInfo propertyInfo = null;
            if (string.IsNullOrEmpty(property))
            {
                throw new ArgumentNullException("PerformValidation requires a registered property to be specified.");
            }
            else
            {
                propertyInfo = ValidatableBase.PropertyValidationCache[this.GetType()]
                    .FirstOrDefault(kv => kv.Key.Name.Equals(property)).Key;
            }

            if (propertyInfo == null)
            {
                throw new ArgumentNullException("PerformValidation requires a registered property to be specified.");
            }

            if (validationProxy != null && validationProxy is IValidatable)
            {
                var proxy = validationProxy as IValidatable;
                proxy.PerformValidation(rule, propertyInfo.Name);
            }
            else
            {
                IMessage result = rule.Validate(propertyInfo, this);
                if (result != null)
                {
                    this.AddValidationMessage(result, propertyInfo.Name);
                }
            }
        }

        /// <summary>
        /// Raises the <see cref="E:ValidationChanged" /> event.
        /// </summary>
        /// <param name="args">The <see cref="ValidationChangedEventArgs"/> instance containing the event data.</param>
        protected virtual void OnValidationChanged(ValidationChangedEventArgs args)
        {
            EventHandler<ValidationChangedEventArgs> handler = this.ValidationChanged;

            if (handler == null)
            {
                return;
            }

            handler(this, args);
        }

        /// <summary>
        /// Registers a property so observers can accessing its ValidationMessages, even when zero exist.
        /// Any property that contains an attribute implementing IValidationRule will be automatically registered.
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        private void RegisterProperty(params string[] propertyName)
        {
            foreach (string property in propertyName)
            {
                if (!this.validationMessages.ContainsKey(property))
                {
                    this.validationMessages[property] = new List<IMessage>();
                }
            }
        }

        /// <summary>
        /// Executes the validation rule supplied for the specified property.
        /// </summary>
        /// <param name="rule">The rule.</param>
        /// <param name="property">The property.</param>
        /// <param name="validationProxy">The validation proxy.</param>
        private void PerformValidation(IValidationRule rule, PropertyInfo property, IValidatable validationProxy = null)
        {
            if (validationProxy != null && validationProxy is ValidatableBase)
            {
                var proxy = validationProxy as ValidatableBase;
                proxy.PerformValidation(rule, property);
            }

            IMessage result = null;
            try
            {
                result = rule.Validate(property, this);
            }
            catch (Exception)
            {
                throw;
            }

            if (result != null)
            {
                this.AddValidationMessage(result, property.Name);
            }
        }

        /// <summary>
        /// Setups the validation, caching validation rules and properties as needed for re-use by other objects.
        /// </summary>
        private void SetupValidation()
        {
            // We instance a cache of property info's and validation rules. If any other Type is instanced that matches ours,
            // we won't need to use reflection to obtain it's members again. We will just hit the cache.
            var cache = new Dictionary<PropertyInfo, IEnumerable<IValidationRule>>();

            if (!ValidatableBase.PropertyValidationCache.ContainsKey(this.GetType()))
            {
                IEnumerable<PropertyInfo> propertiesToValidate = this.GetType().GetProperties()
                    .Where(p => p.GetCustomAttributes(typeof(ValidationAttribute), true).Any());

                // Loop through all property info's and build a collection of validation rules for each property.
                foreach (PropertyInfo property in propertiesToValidate)
                {
                    IEnumerable<ValidationAttribute> rules = property
                        .GetCustomAttributes(typeof(ValidationAttribute), true) as IEnumerable<ValidationAttribute>;
                    cache.Add(property, rules);
                }

                ValidatableBase.PropertyValidationCache[this.GetType()] =
                    new Dictionary<PropertyInfo, IEnumerable<IValidationRule>>(cache);
            }
            else
            {
                cache = ValidatableBase.PropertyValidationCache[this.GetType()];
            }

            // Register each property for this instance once we are done caching.
            foreach (PropertyInfo property in cache.Keys)
            {
                this.RegisterProperty(property.Name);
            }
        }
    }
}
