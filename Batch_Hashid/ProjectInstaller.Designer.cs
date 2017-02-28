namespace Batch_Hashid
{
    partial class ProjectInstaller
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Batch_Hashid = new System.ServiceProcess.ServiceProcessInstaller();
            this.Batch_Hashid_installer = new System.ServiceProcess.ServiceInstaller();
            // 
            // Batch_Hashid
            // 
            this.Batch_Hashid.Account = System.ServiceProcess.ServiceAccount.LocalService;
            this.Batch_Hashid.Password = null;
            this.Batch_Hashid.Username = null;
            // 
            // Batch_Hashid_installer
            // 
            this.Batch_Hashid_installer.DisplayName = "Batch_Hashid";
            this.Batch_Hashid_installer.ServiceName = "Batch_Hashid";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.Batch_Hashid,
            this.Batch_Hashid_installer});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller Batch_Hashid;
        private System.ServiceProcess.ServiceInstaller Batch_Hashid_installer;
    }
}