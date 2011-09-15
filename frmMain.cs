using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace MSSQLtoMySQL
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmMain : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtMSSQLIP;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtMSSQLUser;
		private System.Windows.Forms.TextBox txtMSSQLPwd;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtMSSQLDB;
		private System.Windows.Forms.ListBox lbMSSQLTables;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Button btnExport;
		protected string MSSQLConnString = "Initial Catalog=YourDB;Data Source=localhost;uid=user;pwd=password";
		private System.Windows.Forms.Button btnGetTables;
		private SqlConnection objConn;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.txtMSSQLIP = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtMSSQLUser = new System.Windows.Forms.TextBox();
			this.txtMSSQLPwd = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtMSSQLDB = new System.Windows.Forms.TextBox();
			this.lbMSSQLTables = new System.Windows.Forms.ListBox();
			this.label5 = new System.Windows.Forms.Label();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.btnExport = new System.Windows.Forms.Button();
			this.btnGetTables = new System.Windows.Forms.Button();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(0, 16);
			this.label1.Name = "label1";
			this.label1.TabIndex = 0;
			this.label1.Text = "MSSQL Server IP:";
			// 
			// txtMSSQLIP
			// 
			this.txtMSSQLIP.Location = new System.Drawing.Point(104, 16);
			this.txtMSSQLIP.Name = "txtMSSQLIP";
			this.txtMSSQLIP.Size = new System.Drawing.Size(136, 20);
			this.txtMSSQLIP.TabIndex = 1;
			this.txtMSSQLIP.Text = "localhost";
			this.txtMSSQLIP.TextChanged += new System.EventHandler(this.Fields_TextChanged);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(272, 16);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(32, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "User:";
			// 
			// txtMSSQLUser
			// 
			this.txtMSSQLUser.Location = new System.Drawing.Point(320, 16);
			this.txtMSSQLUser.Name = "txtMSSQLUser";
			this.txtMSSQLUser.Size = new System.Drawing.Size(104, 20);
			this.txtMSSQLUser.TabIndex = 3;
			this.txtMSSQLUser.Text = "user";
			this.txtMSSQLUser.TextChanged += new System.EventHandler(this.Fields_TextChanged);
			// 
			// txtMSSQLPwd
			// 
			this.txtMSSQLPwd.Location = new System.Drawing.Point(320, 40);
			this.txtMSSQLPwd.Name = "txtMSSQLPwd";
			this.txtMSSQLPwd.Size = new System.Drawing.Size(104, 20);
			this.txtMSSQLPwd.TabIndex = 5;
			this.txtMSSQLPwd.Text = "password";
			this.txtMSSQLPwd.TextChanged += new System.EventHandler(this.Fields_TextChanged);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(248, 40);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 23);
			this.label3.TabIndex = 4;
			this.label3.Text = "Password:";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(0, 40);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(104, 23);
			this.label4.TabIndex = 6;
			this.label4.Text = "Database:";
			// 
			// txtMSSQLDB
			// 
			this.txtMSSQLDB.Location = new System.Drawing.Point(104, 40);
			this.txtMSSQLDB.Name = "txtMSSQLDB";
			this.txtMSSQLDB.Size = new System.Drawing.Size(136, 20);
			this.txtMSSQLDB.TabIndex = 7;
			this.txtMSSQLDB.Text = "YourDB";
			this.txtMSSQLDB.TextChanged += new System.EventHandler(this.Fields_TextChanged);
			// 
			// lbMSSQLTables
			// 
			this.lbMSSQLTables.Location = new System.Drawing.Point(8, 136);
			this.lbMSSQLTables.Name = "lbMSSQLTables";
			this.lbMSSQLTables.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
			this.lbMSSQLTables.Size = new System.Drawing.Size(416, 173);
			this.lbMSSQLTables.TabIndex = 8;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(168, 112);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(96, 23);
			this.label5.TabIndex = 9;
			this.label5.Text = "[ MSSQL Tables ]";
			// 
			// btnExport
			// 
			this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnExport.Location = new System.Drawing.Point(168, 320);
			this.btnExport.Name = "btnExport";
			this.btnExport.Size = new System.Drawing.Size(104, 23);
			this.btnExport.TabIndex = 12;
			this.btnExport.Text = "[ Export Data ]";
			this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
			// 
			// btnGetTables
			// 
			this.btnGetTables.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnGetTables.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.btnGetTables.Location = new System.Drawing.Point(168, 72);
			this.btnGetTables.Name = "btnGetTables";
			this.btnGetTables.Size = new System.Drawing.Size(88, 24);
			this.btnGetTables.TabIndex = 13;
			this.btnGetTables.Text = "[ Get Tables ]";
			this.btnGetTables.Click += new System.EventHandler(this.btnGetTables_Click);
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem3});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2});
			this.menuItem1.Text = "&File";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "E&xit";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "&About";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// frmMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(432, 345);
			this.Controls.Add(this.btnGetTables);
			this.Controls.Add(this.btnExport);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.lbMSSQLTables);
			this.Controls.Add(this.txtMSSQLDB);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtMSSQLPwd);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtMSSQLUser);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtMSSQLIP);
			this.Controls.Add(this.label1);
			this.Menu = this.mainMenu1;
			this.Name = "frmMain";
			this.Text = "VPI - MSSQL to MySQL Exporter";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmMain());
		}

		#endregion

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}

		private void Fields_TextChanged(object sender, System.EventArgs e)
		{
			MSSQLConnString = "Initial Catalog="+this.txtMSSQLDB.Text+";Data Source="+this.txtMSSQLIP.Text+";uid="+this.txtMSSQLUser.Text+";pwd="+this.txtMSSQLPwd.Text;
		
		}

		private void btnGetTables_Click(object sender, System.EventArgs e)
		{
			try
			{
				//open connection
				objConn = new SqlConnection(MSSQLConnString);
				objConn.Open();
				MessageBox.Show("Successfully Accessed the Database!");

				SqlCommand cm = new SqlCommand("sp_tables", objConn);
				cm.CommandType = CommandType.StoredProcedure;
				
				cm.Parameters.Add("@table_type", "'TABLE'");
				
				SqlDataAdapter da = new SqlDataAdapter(cm);
				DataSet ds = new DataSet();

				da.Fill(ds);
				
				lbMSSQLTables.DataSource = ds.Tables[0];
				lbMSSQLTables.DisplayMember = "TABLE_NAME";

				objConn.Close();	
                



			}
			catch (Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString());
				
				return;
			}
		}

		private void btnExport_Click(object sender, System.EventArgs e)
		{
			//open connection
			objConn = new SqlConnection(MSSQLConnString);
			objConn.Open();

			SqlCommand cm;
			SqlDataAdapter da;
			DataSet ds;
			string table="";


			StreamWriter sw;
			if(saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				if((sw = new StreamWriter(saveFileDialog1.OpenFile())) != null)
				{
					for(int i = 0; i<lbMSSQLTables.Items.Count; i++)
					{
						if(lbMSSQLTables.SelectedItems.Contains(lbMSSQLTables.Items[i]))
						{
							try
							{
								cm = new SqlCommand("sp_columns", objConn);
								cm.CommandType = CommandType.StoredProcedure;

								string tablename = ((DataRowView)lbMSSQLTables.Items[i]).Row["TABLE_NAME"].ToString();
				
								cm.Parameters.Add("@table_name", tablename);
						
				
								da = new SqlDataAdapter(cm);
								ds = new DataSet();

								da.Fill(ds);
						

								table = "CREATE TABLE "+tablename+" ( ";
								string key = "";
								string auto_inc = "";
								foreach(DataRow dr in ds.Tables[0].Rows)
								{
									auto_inc = "";

									table += dr["COLUMN_NAME"]+" ";

									if(dr["TYPE_NAME"].ToString().IndexOf("identity") != -1)
									{
										key = ", PRIMARY KEY ("+dr["COLUMN_NAME"]+")";
										if(dr["TYPE_NAME"].ToString().IndexOf("int") != -1)
											auto_inc = " auto_increment";
									}
									if(dr["TYPE_NAME"].ToString().Replace(" identity","") == "nvarchar")
										table += "varchar";
									else
										table += dr["TYPE_NAME"].ToString().Replace(" identity","");

									if(dr["TYPE_NAME"].ToString().Replace(" identity","") != "datetime")
										table += "("+dr["PRECISION"]+")";

									if(dr["Nullable"].ToString() == "0")
										table += " NOT NULL";

									if(dr["COLUMN_DEF"].ToString().Length > 0)
										table += " default '" + dr["COLUMN_DEF"].ToString().Replace("(","").Replace(")","") + "'";

									table += auto_inc+",";
						
								}
								table = table.Substring(0,table.Length - 1);
								table += key+" ); ";

								sw.Write(table);
								sw.Write("\n\n");

								cm = new SqlCommand("select * from "+tablename, objConn);
								cm.CommandType = CommandType.Text;

								da = new SqlDataAdapter(cm);
								ds = new DataSet();

								da.Fill(ds, "Rows");

								string rowbegin = "insert into "+tablename+" values (";
								string row = "";
								foreach(DataRow drRow in ds.Tables["Rows"].Rows)
								{
									row = rowbegin;
									for(int col = 0; col < ds.Tables["Rows"].Columns.Count; col++)
									{
										row += "'";
										if(drRow[col].GetType() == typeof(DateTime))
											row += ((DateTime)drRow[col]).ToString("yyyy-MM-dd");
										else if(drRow[col].GetType() == typeof(System.Boolean))
											row += ((bool)drRow[col])?"1":"0";
										else
											row += drRow[col].ToString().Replace("'",@"\'").Trim();

										row += "',";
									}

									row = row.Substring(0, row.Length - 1);
									row += " );";
									sw.Write(row);
									sw.Write("\n");
								}
			
						

							}
							catch (Exception ex)
							{
								System.Windows.Forms.MessageBox.Show(ex.ToString());
				
								return;
							}

						}
				
					}

					sw.Close();
				}
			}
			
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			frmAbout frm = new frmAbout();
			frm.Show();
			
		}
	}
}
