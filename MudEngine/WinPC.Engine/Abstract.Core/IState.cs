﻿namespace WinPC.Engine.Abstract.Core
{
    public interface IState
    {
        void Render(IPlayer player);
        ICommand GetCommand();
    }
}