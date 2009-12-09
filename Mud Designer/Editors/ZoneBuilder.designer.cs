﻿namespace MudDesigner.Editors
{
    partial class ZoneBuilder
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ZoneBuilder));
            this.containerMain = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lstZones = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSelectRealm = new System.Windows.Forms.Button();
            this.btnLoadZone = new System.Windows.Forms.Button();
            this.btnSaveZone = new System.Windows.Forms.Button();
            this.btnDeleteZone = new System.Windows.Forms.Button();
            this.btnNewZone = new System.Windows.Forms.Button();
            this.tabZoneBuilder = new System.Windows.Forms.TabControl();
            this.tabZone = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.propertyZone = new System.Windows.Forms.PropertyGrid();
            this.tabRoomDesigner = new System.Windows.Forms.TabPage();
            this.tabRoomEditor = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.propertyRoom = new System.Windows.Forms.PropertyGrid();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lstRooms = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.btnLoadRoom = new System.Windows.Forms.Button();
            this.btnSaveRoom = new System.Windows.Forms.Button();
            this.btnDeleteRoom = new System.Windows.Forms.Button();
            this.btnNewRoom = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.btnEast = new System.Windows.Forms.Button();
            this.doorwayMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuInstallDoor = new System.Windows.Forms.ToolStripMenuItem();
            this.installDoorwayToAnotherZoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.installReverseDoorwayToSelectedRoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuClearDoorway = new System.Windows.Forms.ToolStripMenuItem();
            this.btnWest = new System.Windows.Forms.Button();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnSouth = new System.Windows.Forms.Button();
            this.btnNorth = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.Help = new System.Windows.Forms.ToolTip(this.components);
            this.containerMain.Panel1.SuspendLayout();
            this.containerMain.Panel2.SuspendLayout();
            this.containerMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabZoneBuilder.SuspendLayout();
            this.tabZone.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabRoomDesigner.SuspendLayout();
            this.tabRoomEditor.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.doorwayMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // containerMain
            // 
            this.containerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.containerMain.Location = new System.Drawing.Point(0, 0);
            this.containerMain.Name = "containerMain";
            // 
            // containerMain.Panel1
            // 
            this.containerMain.Panel1.Controls.Add(this.groupBox1);
            this.containerMain.Panel1.Controls.Add(this.groupBox2);
            // 
            // containerMain.Panel2
            // 
            this.containerMain.Panel2.Controls.Add(this.tabZoneBuilder);
            this.containerMain.Size = new System.Drawing.Size(700, 471);
            this.containerMain.SplitterDistance = 210;
            this.containerMain.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lstZones);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 100);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 371);
            this.groupBox1.TabIndex = 37;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Zone List";
            // 
            // lstZones
            // 
            this.lstZones.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstZones.FormattingEnabled = true;
            this.lstZones.Location = new System.Drawing.Point(3, 16);
            this.lstZones.Name = "lstZones";
            this.lstZones.Size = new System.Drawing.Size(204, 342);
            this.lstZones.Sorted = true;
            this.lstZones.TabIndex = 17;
            this.Help.SetToolTip(this.lstZones, "A collection of Zones that have already been created\r\nand stored within the selec" +
                    "ted Realm.");
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnSelectRealm);
            this.groupBox2.Controls.Add(this.btnLoadZone);
            this.groupBox2.Controls.Add(this.btnSaveZone);
            this.groupBox2.Controls.Add(this.btnDeleteZone);
            this.groupBox2.Controls.Add(this.btnNewZone);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(210, 100);
            this.groupBox2.TabIndex = 35;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Zone Setup";
            // 
            // btnSelectRealm
            // 
            this.btnSelectRealm.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnSelectRealm.Location = new System.Drawing.Point(3, 74);
            this.btnSelectRealm.Name = "btnSelectRealm";
            this.btnSelectRealm.Size = new System.Drawing.Size(204, 23);
            this.btnSelectRealm.TabIndex = 12;
            this.btnSelectRealm.Text = "Select Realm";
            this.Help.SetToolTip(this.btnSelectRealm, "Selects the Realm that your new Zones will be created within");
            this.btnSelectRealm.UseVisualStyleBackColor = true;
            this.btnSelectRealm.Click += new System.EventHandler(this.btnSelectRealm_Click);
            // 
            // btnLoadZone
            // 
            this.btnLoadZone.Location = new System.Drawing.Point(122, 48);
            this.btnLoadZone.Name = "btnLoadZone";
            this.btnLoadZone.Size = new System.Drawing.Size(85, 23);
            this.btnLoadZone.TabIndex = 11;
            this.btnLoadZone.Text = "Load Zone";
            this.btnLoadZone.UseVisualStyleBackColor = true;
            this.btnLoadZone.Click += new System.EventHandler(this.btnLoadZone_Click);
            // 
            // btnSaveZone
            // 
            this.btnSaveZone.Location = new System.Drawing.Point(123, 19);
            this.btnSaveZone.Name = "btnSaveZone";
            this.btnSaveZone.Size = new System.Drawing.Size(84, 23);
            this.btnSaveZone.TabIndex = 10;
            this.btnSaveZone.Text = "Save Zone";
            this.btnSaveZone.UseVisualStyleBackColor = true;
            this.btnSaveZone.Click += new System.EventHandler(this.btnSaveZone_Click);
            // 
            // btnDeleteZone
            // 
            this.btnDeleteZone.Location = new System.Drawing.Point(6, 48);
            this.btnDeleteZone.Name = "btnDeleteZone";
            this.btnDeleteZone.Size = new System.Drawing.Size(85, 23);
            this.btnDeleteZone.TabIndex = 9;
            this.btnDeleteZone.Text = "Delete Zone";
            this.btnDeleteZone.UseVisualStyleBackColor = true;
            // 
            // btnNewZone
            // 
            this.btnNewZone.Location = new System.Drawing.Point(6, 19);
            this.btnNewZone.Name = "btnNewZone";
            this.btnNewZone.Size = new System.Drawing.Size(85, 23);
            this.btnNewZone.TabIndex = 8;
            this.btnNewZone.Text = "New Zone";
            this.btnNewZone.UseVisualStyleBackColor = true;
            this.btnNewZone.Click += new System.EventHandler(this.btnNewZone_Click);
            // 
            // tabZoneBuilder
            // 
            this.tabZoneBuilder.Controls.Add(this.tabZone);
            this.tabZoneBuilder.Controls.Add(this.tabRoomDesigner);
            this.tabZoneBuilder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabZoneBuilder.Location = new System.Drawing.Point(0, 0);
            this.tabZoneBuilder.Name = "tabZoneBuilder";
            this.tabZoneBuilder.SelectedIndex = 0;
            this.tabZoneBuilder.Size = new System.Drawing.Size(486, 471);
            this.tabZoneBuilder.TabIndex = 0;
            // 
            // tabZone
            // 
            this.tabZone.Controls.Add(this.groupBox4);
            this.tabZone.Controls.Add(this.groupBox3);
            this.tabZone.Location = new System.Drawing.Point(4, 22);
            this.tabZone.Name = "tabZone";
            this.tabZone.Padding = new System.Windows.Forms.Padding(3);
            this.tabZone.Size = new System.Drawing.Size(478, 445);
            this.tabZone.TabIndex = 0;
            this.tabZone.Text = "Zone Editing";
            this.tabZone.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Location = new System.Drawing.Point(262, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(208, 436);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.propertyZone);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(253, 439);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Zone Properties";
            // 
            // propertyZone
            // 
            this.propertyZone.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyZone.Location = new System.Drawing.Point(3, 16);
            this.propertyZone.Name = "propertyZone";
            this.propertyZone.Size = new System.Drawing.Size(247, 420);
            this.propertyZone.TabIndex = 0;
            this.propertyZone.ToolbarVisible = false;
            // 
            // tabRoomDesigner
            // 
            this.tabRoomDesigner.Controls.Add(this.tabRoomEditor);
            this.tabRoomDesigner.Location = new System.Drawing.Point(4, 22);
            this.tabRoomDesigner.Name = "tabRoomDesigner";
            this.tabRoomDesigner.Padding = new System.Windows.Forms.Padding(3);
            this.tabRoomDesigner.Size = new System.Drawing.Size(478, 445);
            this.tabRoomDesigner.TabIndex = 1;
            this.tabRoomDesigner.Text = "Room Designer";
            this.tabRoomDesigner.UseVisualStyleBackColor = true;
            // 
            // tabRoomEditor
            // 
            this.tabRoomEditor.Controls.Add(this.tabPage1);
            this.tabRoomEditor.Controls.Add(this.tabPage2);
            this.tabRoomEditor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabRoomEditor.Location = new System.Drawing.Point(3, 3);
            this.tabRoomEditor.Name = "tabRoomEditor";
            this.tabRoomEditor.SelectedIndex = 0;
            this.tabRoomEditor.Size = new System.Drawing.Size(472, 439);
            this.tabRoomEditor.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox7);
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Controls.Add(this.groupBox5);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(464, 413);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Room Setup";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.propertyRoom);
            this.groupBox7.Location = new System.Drawing.Point(222, 6);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(239, 404);
            this.groupBox7.TabIndex = 39;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Room Properties";
            // 
            // propertyRoom
            // 
            this.propertyRoom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyRoom.Location = new System.Drawing.Point(3, 16);
            this.propertyRoom.Name = "propertyRoom";
            this.propertyRoom.Size = new System.Drawing.Size(233, 385);
            this.propertyRoom.TabIndex = 0;
            this.propertyRoom.ToolbarVisible = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lstRooms);
            this.groupBox6.Location = new System.Drawing.Point(6, 87);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(210, 323);
            this.groupBox6.TabIndex = 38;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Room List";
            // 
            // lstRooms
            // 
            this.lstRooms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstRooms.FormattingEnabled = true;
            this.lstRooms.Location = new System.Drawing.Point(3, 16);
            this.lstRooms.Name = "lstRooms";
            this.lstRooms.Size = new System.Drawing.Size(204, 303);
            this.lstRooms.Sorted = true;
            this.lstRooms.TabIndex = 17;
            this.Help.SetToolTip(this.lstRooms, "A collection of Rooms that have already been created\r\nand stored within the curre" +
                    "ntly loaded Zone.");
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.btnLoadRoom);
            this.groupBox5.Controls.Add(this.btnSaveRoom);
            this.groupBox5.Controls.Add(this.btnDeleteRoom);
            this.groupBox5.Controls.Add(this.btnNewRoom);
            this.groupBox5.Location = new System.Drawing.Point(6, 6);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(210, 75);
            this.groupBox5.TabIndex = 36;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Room Setup";
            // 
            // btnLoadRoom
            // 
            this.btnLoadRoom.Location = new System.Drawing.Point(122, 46);
            this.btnLoadRoom.Name = "btnLoadRoom";
            this.btnLoadRoom.Size = new System.Drawing.Size(85, 23);
            this.btnLoadRoom.TabIndex = 11;
            this.btnLoadRoom.Text = "Load Room";
            this.btnLoadRoom.UseVisualStyleBackColor = true;
            this.btnLoadRoom.Click += new System.EventHandler(this.btnLoadRoom_Click);
            // 
            // btnSaveRoom
            // 
            this.btnSaveRoom.Location = new System.Drawing.Point(123, 19);
            this.btnSaveRoom.Name = "btnSaveRoom";
            this.btnSaveRoom.Size = new System.Drawing.Size(84, 23);
            this.btnSaveRoom.TabIndex = 10;
            this.btnSaveRoom.Text = "Save Room";
            this.btnSaveRoom.UseVisualStyleBackColor = true;
            this.btnSaveRoom.Click += new System.EventHandler(this.btnSaveRoom_Click);
            // 
            // btnDeleteRoom
            // 
            this.btnDeleteRoom.Location = new System.Drawing.Point(6, 48);
            this.btnDeleteRoom.Name = "btnDeleteRoom";
            this.btnDeleteRoom.Size = new System.Drawing.Size(85, 23);
            this.btnDeleteRoom.TabIndex = 9;
            this.btnDeleteRoom.Text = "Delete Room";
            this.btnDeleteRoom.UseVisualStyleBackColor = true;
            // 
            // btnNewRoom
            // 
            this.btnNewRoom.Location = new System.Drawing.Point(6, 19);
            this.btnNewRoom.Name = "btnNewRoom";
            this.btnNewRoom.Size = new System.Drawing.Size(85, 23);
            this.btnNewRoom.TabIndex = 8;
            this.btnNewRoom.Text = "New Room";
            this.btnNewRoom.UseVisualStyleBackColor = true;
            this.btnNewRoom.Click += new System.EventHandler(this.btnNewRoom_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox8);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(464, 413);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Room Doorways";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.btnEast);
            this.groupBox8.Controls.Add(this.btnWest);
            this.groupBox8.Controls.Add(this.btnDown);
            this.groupBox8.Controls.Add(this.btnSouth);
            this.groupBox8.Controls.Add(this.btnNorth);
            this.groupBox8.Controls.Add(this.btnUp);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox8.Location = new System.Drawing.Point(3, 3);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(458, 407);
            this.groupBox8.TabIndex = 0;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Available Travel Directions";
            // 
            // btnEast
            // 
            this.btnEast.BackColor = System.Drawing.Color.Gray;
            this.btnEast.ContextMenuStrip = this.doorwayMenuStrip;
            this.btnEast.FlatAppearance.BorderSize = 2;
            this.btnEast.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnEast.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEast.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEast.Location = new System.Drawing.Point(334, 159);
            this.btnEast.Name = "btnEast";
            this.btnEast.Size = new System.Drawing.Size(118, 93);
            this.btnEast.TabIndex = 7;
            this.btnEast.Text = "East";
            this.btnEast.UseVisualStyleBackColor = false;
            // 
            // doorwayMenuStrip
            // 
            this.doorwayMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuInstallDoor,
            this.toolStripMenuItem2,
            this.mnuClearDoorway});
            this.doorwayMenuStrip.Name = "doorwayMenuStrip";
            this.doorwayMenuStrip.Size = new System.Drawing.Size(162, 76);
            this.doorwayMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.doorwayMenuStrip_Opening);
            // 
            // mnuInstallDoor
            // 
            this.mnuInstallDoor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.installDoorwayToAnotherZoneToolStripMenuItem,
            this.toolStripMenuItem1,
            this.installReverseDoorwayToSelectedRoomToolStripMenuItem});
            this.mnuInstallDoor.Name = "mnuInstallDoor";
            this.mnuInstallDoor.Size = new System.Drawing.Size(161, 22);
            this.mnuInstallDoor.Text = "Install New Door";
            // 
            // installDoorwayToAnotherZoneToolStripMenuItem
            // 
            this.installDoorwayToAnotherZoneToolStripMenuItem.Name = "installDoorwayToAnotherZoneToolStripMenuItem";
            this.installDoorwayToAnotherZoneToolStripMenuItem.Size = new System.Drawing.Size(293, 22);
            this.installDoorwayToAnotherZoneToolStripMenuItem.Text = "Install Doorway to another Zone";
            this.installDoorwayToAnotherZoneToolStripMenuItem.ToolTipText = "Opens the Doorway Manager giving you the ability\r\nto link a Room located in a dif" +
                "ferent Zone or Realm.";
            this.installDoorwayToAnotherZoneToolStripMenuItem.Click += new System.EventHandler(this.installDoorwayToAnotherZoneToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(290, 6);
            // 
            // installReverseDoorwayToSelectedRoomToolStripMenuItem
            // 
            this.installReverseDoorwayToSelectedRoomToolStripMenuItem.Name = "installReverseDoorwayToSelectedRoomToolStripMenuItem";
            this.installReverseDoorwayToSelectedRoomToolStripMenuItem.Size = new System.Drawing.Size(293, 22);
            this.installReverseDoorwayToSelectedRoomToolStripMenuItem.Text = "Install Reverse Doorway to selected Room";
            this.installReverseDoorwayToSelectedRoomToolStripMenuItem.ToolTipText = resources.GetString("installReverseDoorwayToSelectedRoomToolStripMenuItem.ToolTipText");
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(158, 6);
            // 
            // mnuClearDoorway
            // 
            this.mnuClearDoorway.Name = "mnuClearDoorway";
            this.mnuClearDoorway.Size = new System.Drawing.Size(161, 22);
            this.mnuClearDoorway.Text = "Clear Doorway";
            // 
            // btnWest
            // 
            this.btnWest.BackColor = System.Drawing.Color.Gray;
            this.btnWest.ContextMenuStrip = this.doorwayMenuStrip;
            this.btnWest.FlatAppearance.BorderSize = 2;
            this.btnWest.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnWest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWest.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWest.Location = new System.Drawing.Point(6, 159);
            this.btnWest.Name = "btnWest";
            this.btnWest.Size = new System.Drawing.Size(118, 93);
            this.btnWest.TabIndex = 6;
            this.btnWest.Text = "West";
            this.btnWest.UseVisualStyleBackColor = false;
            // 
            // btnDown
            // 
            this.btnDown.BackColor = System.Drawing.Color.Gray;
            this.btnDown.ContextMenuStrip = this.doorwayMenuStrip;
            this.btnDown.FlatAppearance.BorderSize = 2;
            this.btnDown.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDown.Location = new System.Drawing.Point(166, 350);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(118, 51);
            this.btnDown.TabIndex = 5;
            this.btnDown.Text = "Down";
            this.btnDown.UseVisualStyleBackColor = false;
            // 
            // btnSouth
            // 
            this.btnSouth.BackColor = System.Drawing.Color.Gray;
            this.btnSouth.ContextMenuStrip = this.doorwayMenuStrip;
            this.btnSouth.FlatAppearance.BorderSize = 2;
            this.btnSouth.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnSouth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSouth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSouth.Location = new System.Drawing.Point(166, 258);
            this.btnSouth.Name = "btnSouth";
            this.btnSouth.Size = new System.Drawing.Size(118, 86);
            this.btnSouth.TabIndex = 4;
            this.btnSouth.Text = "South";
            this.btnSouth.UseVisualStyleBackColor = false;
            // 
            // btnNorth
            // 
            this.btnNorth.BackColor = System.Drawing.Color.Gray;
            this.btnNorth.ContextMenuStrip = this.doorwayMenuStrip;
            this.btnNorth.FlatAppearance.BorderSize = 2;
            this.btnNorth.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnNorth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNorth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNorth.Location = new System.Drawing.Point(166, 67);
            this.btnNorth.Name = "btnNorth";
            this.btnNorth.Size = new System.Drawing.Size(118, 86);
            this.btnNorth.TabIndex = 3;
            this.btnNorth.Text = "North";
            this.btnNorth.UseVisualStyleBackColor = false;
            // 
            // btnUp
            // 
            this.btnUp.BackColor = System.Drawing.Color.Gray;
            this.btnUp.ContextMenuStrip = this.doorwayMenuStrip;
            this.btnUp.FlatAppearance.BorderSize = 2;
            this.btnUp.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUp.Location = new System.Drawing.Point(166, 10);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(118, 51);
            this.btnUp.TabIndex = 0;
            this.btnUp.Text = "Up";
            this.btnUp.UseVisualStyleBackColor = false;
            // 
            // Help
            // 
            this.Help.AutoPopDelay = 12000;
            this.Help.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.Help.InitialDelay = 1000;
            this.Help.IsBalloon = true;
            this.Help.ReshowDelay = 100;
            this.Help.ToolTipTitle = "Zone Designer";
            // 
            // ZoneBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 471);
            this.Controls.Add(this.containerMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ZoneBuilder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Zone Builder (No Realm Selected)";
            this.containerMain.Panel1.ResumeLayout(false);
            this.containerMain.Panel2.ResumeLayout(false);
            this.containerMain.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tabZoneBuilder.ResumeLayout(false);
            this.tabZone.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tabRoomDesigner.ResumeLayout(false);
            this.tabRoomEditor.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.doorwayMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer containerMain;
        private System.Windows.Forms.ToolTip Help;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnLoadZone;
        private System.Windows.Forms.Button btnSaveZone;
        private System.Windows.Forms.Button btnDeleteZone;
        private System.Windows.Forms.Button btnNewZone;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lstZones;
        private System.Windows.Forms.TabControl tabZoneBuilder;
        private System.Windows.Forms.TabPage tabZone;
        private System.Windows.Forms.TabPage tabRoomDesigner;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.PropertyGrid propertyZone;
        private System.Windows.Forms.Button btnSelectRealm;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TabControl tabRoomEditor;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button btnLoadRoom;
        private System.Windows.Forms.Button btnSaveRoom;
        private System.Windows.Forms.Button btnDeleteRoom;
        private System.Windows.Forms.Button btnNewRoom;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ListBox lstRooms;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.PropertyGrid propertyRoom;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Button btnNorth;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnSouth;
        private System.Windows.Forms.Button btnWest;
        private System.Windows.Forms.Button btnEast;
        private System.Windows.Forms.ContextMenuStrip doorwayMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem mnuInstallDoor;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem mnuClearDoorway;
        private System.Windows.Forms.ToolStripMenuItem installDoorwayToAnotherZoneToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem installReverseDoorwayToSelectedRoomToolStripMenuItem;

    }
}