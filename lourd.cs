
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using MQTTnet.Client;
using System.Text.Json;
using uPLibrary.Networking.M2Mqtt;
using MQTTnet.Client.Options;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt;
using System.IO;
using System.Text.Json;
using MQTTnet.Client.Options;
using uPLibrary.Networking.M2Mqtt;
using System.Drawing;
using System.Collections.ObjectModel;
using System.Media;
using astroroad99;


namespace lourd
{
    public partial class lourd : Form
    {
        //**** valeur qui permet de stocker la valeur dans une nouvelle case de la liste
        int callrandom =0;





        // s'il y a 5 cibles, il faut que   n >4  dans la question nextquestionclick()
        // s'il y a 4 cibles, il faut que   n >3  dans la question nextquestionclick()
        // s'il y a 3 cibles, il faut que   n >2  dans la question nextquestionclick()

        //private tag

        private static int tag2 = 26884;


        //***tailletableau: il est en static parceque la methode qui l'utilise est en statique  si non ça ne marchera pas ****
        int tailletableau = 6;
        private int T(int s)
        {
            int[] T = new int[tailletableau];
          
            T[1] = 26885;
            T[2] = 26921;
            T[3] = 26963;
            T[4] = 26888;
//avant T[4]=26888 est en commentaire et initialisation du tableau est  new int [5]
            return T[s];
        }

        public int tag2p
        {

            get { return tag2; }
            set { tag2 = value; }

        }




        //check la distance 
        private double resultvalue;


        //private static double redifitag1x;

        //quiz question ;
        
        int correctAnswer;
        int questionNumber;
        int Score;
        int totalQuestions;

        //vie
        int vie = 2;


        Button b1 = new Button();
        Button b2 = new Button();
        private Button Start;
        private System.ComponentModel.IContainer components;
        private Label label1;

        //public   Dictionary<int ,Tag1> dico1 ;
        private static double valuedistance;

        public static double valueredifinitiondistancetagX
        {
            get { return valuedistance; }
            set { valuedistance = value; }
        }





        private static double valuedistance2;

        public static double valueredifinitiondistancetag2X
        {
            get { return valuedistance2; }
            set { valuedistance2 = value; }
        }





        private static double valuedistance1;

        public static double valueredifinitiondistancetag1X
        {
            get { return valuedistance1; }
            set { valuedistance1 = value; }
        }




        //ces valeurs me permetteront de les reutiliser dans toute la classe
        private static double valueredifinitiontag1X;
        private static double valueredifinitiontag1Y;
        private static double valueredifinitiontag2X;
        private Timer timer1;
        private Label label2;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem hToolStripMenuItem;
        private ToolStripMenuItem butDuJeuToolStripMenuItem;
        private ToolStripMenuItem noticeToolStripMenuItem;
        private Panel panel1;
        private PictureBox pictureboxdepart;
        private Label label_blo;
        private Button but4;
        private Button but3;
        private Button but2;
        private Button but1;
        private Label labelquestion;
        private PictureBox pictureBox1;
        private Label labelreponse;
        private ToolStripMenuItem sonDuJeuToolStripMenuItem;
        private ToolStripMenuItem playToolStripMenuItem;
        private ToolStripMenuItem stopToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panelacceuil;
        private Panel panelenigme;
        private Panel panelsearch;
        private PictureBox picturesonna;
        private Label labelmessageform3;
        private Button nextquestion;
        private Label labelsecondchance;
        private Timer timer2;
        private Panel panelgameover;
        private PictureBox picturegameover;
        private Timer timersearch;
        private Label labeltimersearch;
        private Button Exit;
        private Button recommence;
        private Label recapitulatif;
       
        
        
        
        private static double valueredifinitiontag2Y;
        //encodage de cette variable double permettre de stocker la valeur dans une variable privée
        public static double redifinitiontag1X
        {
            get { return valueredifinitiontag1X; }
            set { valueredifinitiontag1X = value; }
        }
        public static double redifinitiontag1Y
        {
            get { return valueredifinitiontag1Y; }
            set { valueredifinitiontag1Y = value; }
        }
        public static double redifinitiontag2X
        {
            get { return valueredifinitiontag2X; }
            set { valueredifinitiontag2X = value; }
        }
        public static double redifinitiontag2Y
        {
            get { return valueredifinitiontag2Y; }
            set { valueredifinitiontag2Y = value; }
        }




        public List<int> stockagevaleur = new List<int>();

        public lourd()
        {
            InitializeComponent();
            
            var sound1 = new SoundPlayer(@"C:\Users\aliou\Music\Pirate-Love-Song-Black-Heart.wav");
            
            //initialisattion de la liste des reponses qui doivent être stocké
            for (int i = 0; i < tailletableau ; i++)
            {
                stockagevaleur.Add(0);
            }
        }


        static void Main(string[] args)
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            

            uPLibrary.Networking.M2Mqtt.MqttClient mymqttclient = new uPLibrary.Networking.M2Mqtt.MqttClient("Localhost");
            Console.WriteLine("========welcom ASTROROAD99 ======");

            //inscription au broker
            mymqttclient.Subscribe(new string[] { "tag26886/" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
            mymqttclient.Subscribe(new string[] { "tags" }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });

            //creation du client
            string clientId = Guid.NewGuid().ToString();
            MqttClientOptions P = new MqttClientOptions();
            mymqttclient.Connect(clientId, "ali", "isib", true, keepAlivePeriod: 5);

            //messsage qui affiche les deux tags
            Console.WriteLine("Subscriber:tag1/");
            Console.WriteLine("Subscriber:tag2/");

            mymqttclient.MqttMsgPublishReceived += Mymqttclient_MqttMsgPublishReceived;


            Application.Run(new lourd());





        }

        private static void Mymqttclient_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {

            string path = @"C:\Users\aliou\OneDrive\Bureau\TOCOSS.txt";
            if (File.Exists(path))
            {//si le fichier existe

                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(path))
                {
                    string s = System.Text.Encoding.Default.GetString(e.Message);
                   
                    sw.WriteLine(s);
                   
                }
            }



            // Open the file to read from.
            using (StreamReader sr = File.OpenText(path))
            {
                string s;
                while ((s = sr.ReadLine()) != null) { 
                    
                    //tant que le msg qui va être lu n'est pas null cad tant que <<s !=" ";>> (n'est pas vide =null)  on applique cette deserialisation
                     
               
                    Collection<jsondeserialize.Example> todo = JsonSerializer.Deserialize<Collection<jsondeserialize.Example>>(File.ReadAllText(path));
                    //	File.ReadAllText(path): lit tout le texte qui se trouve dans le fichier et le ferme
                    foreach (var item in todo)
                    {
                        //Dictionary<float, int> dico = new Dictionary<float, int>;

                        if (item.data.coordinates is null)
                        {

                            Console.WriteLine("pas de coordonnées");
                        }
                        else
                        {
                            //float tagid = (float) double.Parse(item.tagId);
                            int tagid = int.Parse(item.tagId);


                            Tag1 TAG1 = new Tag1();
                            Tag2 TAG2 = new Tag2();
                            //different tags qui ne doivent pas être supprimés
                           
                            //****Tag du joueur:*****
                            int tag1 = 26925;
                            //***
                          


                            if (tag1 == tagid)
                            {
                                TAG1.TagId1 = int.Parse(item.tagId);
                                TAG1.TaginX1 = item.data.coordinates.x;
                                TAG1.TaginY1 = item.data.coordinates.y;
                                TAG1.TaginZ1 = item.data.coordinates.z;

                                var dico1 = new Dictionary<int, Tag1>();

                                dico1.Add(tagid, TAG1);

                                redifinitiontag1X = (double)(TAG1.TaginX1 );
                                redifinitiontag1Y = (double)(TAG1.TaginY1 );

                                /*
                                redifinitiontag1X = (double)(TAG1.TaginX1 / 25);
                                redifinitiontag1Y = (double)(TAG1.TaginY1 / 25);
                                */
                                double carrex1 = (valueredifinitiontag1X * valueredifinitiontag1X);
                                double carrey1 = (valueredifinitiontag1Y * valueredifinitiontag1Y);
                                double dist1 = Math.Sqrt((carrex1) + (carrey1));
                                valueredifinitiondistancetag1X = dist1;

                            }
                            

                            else if (tag2 == tagid)
                            {
                                TAG2.TagId2 = int.Parse(item.tagId);
                                TAG2.TaginX2 = item.data.coordinates.x;
                                TAG2.TaginY2 = item.data.coordinates.y;
                                TAG2.TaginZ2 = item.data.coordinates.z;

                             

                                var dico2 = new Dictionary<int, Tag2>();

                                dico2.Add(tagid, TAG2);
                                

                                redifinitiontag2X = (double)(TAG2.TaginX2 ); 
                                redifinitiontag2Y = (double)(TAG2.TaginY2 );

                                double carrex2 = (valueredifinitiontag2X * valueredifinitiontag2X);
                                double carrey2 = (valueredifinitiontag2Y * valueredifinitiontag2Y);
                                double dist2 = Math.Sqrt((carrex2) + (carrey2));
                                valueredifinitiondistancetag2X = dist2;

                            }

                            Console.WriteLine(redifinitiontag1X + "," + redifinitiontag1Y);
                            Console.WriteLine(redifinitiontag2X + "," + redifinitiontag2Y);

                        }

                    }




                }
            }

        }



        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(lourd));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.hToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.butDuJeuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sonDuJeuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.playToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noticeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.labelsecondchance = new System.Windows.Forms.Label();
            this.labelreponse = new System.Windows.Forms.Label();
            this.but4 = new System.Windows.Forms.Button();
            this.but3 = new System.Windows.Forms.Button();
            this.but2 = new System.Windows.Forms.Button();
            this.but1 = new System.Windows.Forms.Button();
            this.labelquestion = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_blo = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panelacceuil = new System.Windows.Forms.Panel();
            this.pictureboxdepart = new System.Windows.Forms.PictureBox();
            this.panelenigme = new System.Windows.Forms.Panel();
            this.panelsearch = new System.Windows.Forms.Panel();
            this.labeltimersearch = new System.Windows.Forms.Label();
            this.nextquestion = new System.Windows.Forms.Button();
            this.labelmessageform3 = new System.Windows.Forms.Label();
            this.picturesonna = new System.Windows.Forms.PictureBox();
            this.panelgameover = new System.Windows.Forms.Panel();
            this.recapitulatif = new System.Windows.Forms.Label();
            this.Exit = new System.Windows.Forms.Button();
            this.recommence = new System.Windows.Forms.Button();
            this.picturegameover = new System.Windows.Forms.PictureBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timersearch = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.panelacceuil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxdepart)).BeginInit();
            this.panelenigme.SuspendLayout();
            this.panelsearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturesonna)).BeginInit();
            this.panelgameover.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturegameover)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 256);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "..";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 214);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "..";
            // 
            // Start
            // 
            this.Start.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.Start.Location = new System.Drawing.Point(42, 448);
            this.Start.Name = "Start";
            this.Start.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Start.Size = new System.Drawing.Size(176, 60);
            this.Start.TabIndex = 0;
            this.Start.Text = "Start";
            this.Start.UseVisualStyleBackColor = false;
            this.Start.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hToolStripMenuItem,
            this.noticeToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1646, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // hToolStripMenuItem
            // 
            this.hToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.butDuJeuToolStripMenuItem,
            this.sonDuJeuToolStripMenuItem});
            this.hToolStripMenuItem.Name = "hToolStripMenuItem";
            this.hToolStripMenuItem.Size = new System.Drawing.Size(52, 24);
            this.hToolStripMenuItem.Text = "aide";
            // 
            // butDuJeuToolStripMenuItem
            // 
            this.butDuJeuToolStripMenuItem.Name = "butDuJeuToolStripMenuItem";
            this.butDuJeuToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.butDuJeuToolStripMenuItem.Text = "but du jeu";
            this.butDuJeuToolStripMenuItem.Click += new System.EventHandler(this.butDuJeuToolStripMenuItem_Click);
            // 
            // sonDuJeuToolStripMenuItem
            // 
            this.sonDuJeuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.playToolStripMenuItem,
            this.stopToolStripMenuItem});
            this.sonDuJeuToolStripMenuItem.Name = "sonDuJeuToolStripMenuItem";
            this.sonDuJeuToolStripMenuItem.Size = new System.Drawing.Size(162, 26);
            this.sonDuJeuToolStripMenuItem.Text = "Son du jeu";
            // 
            // playToolStripMenuItem
            // 
            this.playToolStripMenuItem.Name = "playToolStripMenuItem";
            this.playToolStripMenuItem.Size = new System.Drawing.Size(121, 26);
            this.playToolStripMenuItem.Text = "play";
            this.playToolStripMenuItem.Click += new System.EventHandler(this.playToolStripMenuItem_Click);
            // 
            // stopToolStripMenuItem
            // 
            this.stopToolStripMenuItem.Name = "stopToolStripMenuItem";
            this.stopToolStripMenuItem.Size = new System.Drawing.Size(121, 26);
            this.stopToolStripMenuItem.Text = "stop";
            this.stopToolStripMenuItem.Click += new System.EventHandler(this.stopToolStripMenuItem_Click);
            // 
            // noticeToolStripMenuItem
            // 
            this.noticeToolStripMenuItem.Name = "noticeToolStripMenuItem";
            this.noticeToolStripMenuItem.Size = new System.Drawing.Size(47, 24);
            this.noticeToolStripMenuItem.Text = "Exit";
            this.noticeToolStripMenuItem.Click += new System.EventHandler(this.noticeToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Navy;
            this.panel1.Controls.Add(this.labelsecondchance);
            this.panel1.Controls.Add(this.labelreponse);
            this.panel1.Controls.Add(this.but4);
            this.panel1.Controls.Add(this.but3);
            this.panel1.Controls.Add(this.but2);
            this.panel1.Controls.Add(this.but1);
            this.panel1.Controls.Add(this.labelquestion);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(432, 507);
            this.panel1.TabIndex = 5;
            // 
            // labelsecondchance
            // 
            this.labelsecondchance.AutoSize = true;
            this.labelsecondchance.Location = new System.Drawing.Point(69, 466);
            this.labelsecondchance.Name = "labelsecondchance";
            this.labelsecondchance.Size = new System.Drawing.Size(20, 17);
            this.labelsecondchance.TabIndex = 8;
            this.labelsecondchance.Text = "...";
            // 
            // labelreponse
            // 
            this.labelreponse.AutoSize = true;
            this.labelreponse.BackColor = System.Drawing.Color.AliceBlue;
            this.labelreponse.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelreponse.Location = new System.Drawing.Point(27, 408);
            this.labelreponse.Name = "labelreponse";
            this.labelreponse.Size = new System.Drawing.Size(339, 25);
            this.labelreponse.TabIndex = 6;
            this.labelreponse.Text = "bonne reponse/mauvaise reponse\r\n";
            // 
            // but4
            // 
            this.but4.Location = new System.Drawing.Point(245, 364);
            this.but4.Name = "but4";
            this.but4.Size = new System.Drawing.Size(90, 23);
            this.but4.TabIndex = 5;
            this.but4.Tag = "4";
            this.but4.Text = "X";
            this.but4.UseVisualStyleBackColor = true;
            this.but4.Click += new System.EventHandler(this.checkanswers);
            // 
            // but3
            // 
            this.but3.Location = new System.Drawing.Point(15, 364);
            this.but3.Name = "but3";
            this.but3.Size = new System.Drawing.Size(91, 23);
            this.but3.TabIndex = 4;
            this.but3.Tag = "3";
            this.but3.Text = "X";
            this.but3.UseVisualStyleBackColor = true;
            this.but3.Click += new System.EventHandler(this.checkanswers);
            // 
            // but2
            // 
            this.but2.Location = new System.Drawing.Point(245, 319);
            this.but2.Name = "but2";
            this.but2.Size = new System.Drawing.Size(90, 23);
            this.but2.TabIndex = 3;
            this.but2.Tag = "2";
            this.but2.Text = "X";
            this.but2.UseVisualStyleBackColor = true;
            this.but2.Click += new System.EventHandler(this.checkanswers);
            // 
            // but1
            // 
            this.but1.Location = new System.Drawing.Point(15, 319);
            this.but1.Name = "but1";
            this.but1.Size = new System.Drawing.Size(91, 23);
            this.but1.TabIndex = 2;
            this.but1.Tag = "1";
            this.but1.Text = "X";
            this.but1.UseVisualStyleBackColor = true;
            this.but1.Click += new System.EventHandler(this.checkanswers);
            // 
            // labelquestion
            // 
            this.labelquestion.BackColor = System.Drawing.Color.AliceBlue;
            this.labelquestion.Location = new System.Drawing.Point(29, 261);
            this.labelquestion.Name = "labelquestion";
            this.labelquestion.Size = new System.Drawing.Size(346, 35);
            this.labelquestion.TabIndex = 1;
            this.labelquestion.Text = "Question";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::lourd.Properties.Resources.ddsof;
            this.pictureBox1.Location = new System.Drawing.Point(35, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(340, 214);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label_blo
            // 
            this.label_blo.AutoSize = true;
            this.label_blo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.label_blo.Font = new System.Drawing.Font("Ravie", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_blo.Location = new System.Drawing.Point(6, 4);
            this.label_blo.Name = "label_blo";
            this.label_blo.Size = new System.Drawing.Size(280, 40);
            this.label_blo.TabIndex = 7;
            this.label_blo.Text = "BLO III Game";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 39.24381F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60.75619F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 342F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 455F));
            this.tableLayoutPanel1.Controls.Add(this.panelacceuil, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelenigme, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelsearch, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panelgameover, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(87, 38);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1479, 520);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // panelacceuil
            // 
            this.panelacceuil.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.panelacceuil.Controls.Add(this.pictureboxdepart);
            this.panelacceuil.Controls.Add(this.label_blo);
            this.panelacceuil.Controls.Add(this.Start);
            this.panelacceuil.Location = new System.Drawing.Point(3, 3);
            this.panelacceuil.Name = "panelacceuil";
            this.panelacceuil.Size = new System.Drawing.Size(261, 514);
            this.panelacceuil.TabIndex = 0;
            this.panelacceuil.Paint += new System.Windows.Forms.PaintEventHandler(this.panelacceuil_Paint);
            // 
            // pictureboxdepart
            // 
            this.pictureboxdepart.Image = ((System.Drawing.Image)(resources.GetObject("pictureboxdepart.Image")));
            this.pictureboxdepart.Location = new System.Drawing.Point(3, 47);
            this.pictureboxdepart.Name = "pictureboxdepart";
            this.pictureboxdepart.Size = new System.Drawing.Size(290, 397);
            this.pictureboxdepart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureboxdepart.TabIndex = 6;
            this.pictureboxdepart.TabStop = false;
            // 
            // panelenigme
            // 
            this.panelenigme.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panelenigme.Controls.Add(this.panel1);
            this.panelenigme.Location = new System.Drawing.Point(270, 3);
            this.panelenigme.Name = "panelenigme";
            this.panelenigme.Size = new System.Drawing.Size(408, 514);
            this.panelenigme.TabIndex = 1;
            // 
            // panelsearch
            // 
            this.panelsearch.BackColor = System.Drawing.Color.Black;
            this.panelsearch.Controls.Add(this.labeltimersearch);
            this.panelsearch.Controls.Add(this.nextquestion);
            this.panelsearch.Controls.Add(this.labelmessageform3);
            this.panelsearch.Controls.Add(this.picturesonna);
            this.panelsearch.Location = new System.Drawing.Point(684, 3);
            this.panelsearch.Name = "panelsearch";
            this.panelsearch.Size = new System.Drawing.Size(336, 346);
            this.panelsearch.TabIndex = 2;
            // 
            // labeltimersearch
            // 
            this.labeltimersearch.AutoSize = true;
            this.labeltimersearch.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.labeltimersearch.Location = new System.Drawing.Point(136, 4);
            this.labeltimersearch.Name = "labeltimersearch";
            this.labeltimersearch.Size = new System.Drawing.Size(44, 17);
            this.labeltimersearch.TabIndex = 4;
            this.labeltimersearch.Text = "00:00";
            // 
            // nextquestion
            // 
            this.nextquestion.Location = new System.Drawing.Point(3, 244);
            this.nextquestion.Name = "nextquestion";
            this.nextquestion.Size = new System.Drawing.Size(75, 23);
            this.nextquestion.TabIndex = 3;
            this.nextquestion.Text = "Check";
            this.nextquestion.UseVisualStyleBackColor = true;
            this.nextquestion.Click += new System.EventHandler(this.nextquestion_Click);
            // 
            // labelmessageform3
            // 
            this.labelmessageform3.AutoSize = true;
            this.labelmessageform3.BackColor = System.Drawing.Color.White;
            this.labelmessageform3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelmessageform3.Location = new System.Drawing.Point(84, 247);
            this.labelmessageform3.Name = "labelmessageform3";
            this.labelmessageform3.Size = new System.Drawing.Size(84, 20);
            this.labelmessageform3.TabIndex = 1;
            this.labelmessageform3.Text = "message";
            // 
            // picturesonna
            // 
            this.picturesonna.Image = global::lourd.Properties.Resources.ZF6H;
            this.picturesonna.InitialImage = global::lourd.Properties.Resources.ZF6H;
            this.picturesonna.Location = new System.Drawing.Point(3, 34);
            this.picturesonna.Name = "picturesonna";
            this.picturesonna.Size = new System.Drawing.Size(317, 198);
            this.picturesonna.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picturesonna.TabIndex = 0;
            this.picturesonna.TabStop = false;
            // 
            // panelgameover
            // 
            this.panelgameover.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panelgameover.Controls.Add(this.recapitulatif);
            this.panelgameover.Controls.Add(this.Exit);
            this.panelgameover.Controls.Add(this.recommence);
            this.panelgameover.Controls.Add(this.picturegameover);
            this.panelgameover.Location = new System.Drawing.Point(1026, 3);
            this.panelgameover.Name = "panelgameover";
            this.panelgameover.Size = new System.Drawing.Size(450, 508);
            this.panelgameover.TabIndex = 3;
            // 
            // recapitulatif
            // 
            this.recapitulatif.AutoSize = true;
            this.recapitulatif.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recapitulatif.Location = new System.Drawing.Point(283, 26);
            this.recapitulatif.Name = "recapitulatif";
            this.recapitulatif.Size = new System.Drawing.Size(35, 25);
            this.recapitulatif.TabIndex = 3;
            this.recapitulatif.Text = "txt";
            // 
            // Exit
            // 
            this.Exit.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.Exit.Location = new System.Drawing.Point(345, 400);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(110, 37);
            this.Exit.TabIndex = 2;
            this.Exit.Text = "Exit";
            this.Exit.UseVisualStyleBackColor = false;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // recommence
            // 
            this.recommence.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.recommence.Location = new System.Drawing.Point(345, 313);
            this.recommence.Name = "recommence";
            this.recommence.Size = new System.Drawing.Size(108, 42);
            this.recommence.TabIndex = 1;
            this.recommence.Text = "recommencer";
            this.recommence.UseVisualStyleBackColor = false;
            this.recommence.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // picturegameover
            // 
            this.picturegameover.ErrorImage = null;
            this.picturegameover.Image = global::lourd.Properties.Resources.SS;
            this.picturegameover.InitialImage = global::lourd.Properties.Resources.SS;
            this.picturegameover.Location = new System.Drawing.Point(3, 0);
            this.picturegameover.Name = "picturegameover";
            this.picturegameover.Size = new System.Drawing.Size(438, 505);
            this.picturegameover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picturegameover.TabIndex = 0;
            this.picturegameover.TabStop = false;
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 1000;
           // this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timersearch
            // 
            this.timersearch.Interval = 1000;
            // 
            // lourd
            // 
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1646, 603);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "lourd";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panelacceuil.ResumeLayout(false);
            this.panelacceuil.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxdepart)).EndInit();
            this.panelenigme.ResumeLayout(false);
            this.panelsearch.ResumeLayout(false);
            this.panelsearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturesonna)).EndInit();
            this.panelgameover.ResumeLayout(false);
            this.panelgameover.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picturegameover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        private void button1_Click(object sender, EventArgs e)
        {

            
                            }





         private void timer1_Tick(object sender, EventArgs e)
        {

            label1.Text = (valuedistance1).ToString();
           
            label2.Text = (valuedistance2).ToString();
            
            string s = label_blo.Text.ToString();
            
            timer1.Interval = 100;

           
        }





        private void butDuJeuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
           
            form2.Show();

        }





        private void noticeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("êtes vous sûre de quitter?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Application.Exit();
                
                Environment.Exit(1);
            }

        }

   

     

        Timer timesearch11 = new Timer();
        //evenement qui verifie si la question est vraie ou fausse et qui peux annocer le game over
       
        private void checkanswers(object sender, EventArgs e)
        {
            var senderObject = (Button)sender;
           
            int buttonTag = Convert.ToInt32(senderObject.Tag);
            
            if (buttonTag == correctAnswer)
            {

                string reponse = "bonne reponse";
            
                Score += 1;
                //labelreponse.Visible = true;
                
                labelreponse.Text = reponse.ToString();
                
                labelreponse.BackColor = Color.Green;
                
              
                
                this.Controls.Add(panelsearch);
                
                this.Controls.Remove(panelenigme);
                
                this.Size = new Size(500, 600);
                
                panelsearch.Location = new Point(64, 31);
                
                panelsearch.Size = new Size(this.Width, this.Height);
                
                timesearch11.Enabled = true;
                
                timesearch11.Interval = 1000;
                
                timesearch11.Tick += Timesearch11;

                
            }
            else
            {

                labelsecondchance.Visible = true;
                
                string b = "vous avez droit à une seconde chance";
                
                labelsecondchance.Text = b.ToString();
                
                labelsecondchance.BackColor = Color.White;
                
                string reponse = "mauvaise reponse";
                
                labelreponse.Text = reponse.ToString();
                
                labelreponse.BackColor = Color.Red;


                vie = vie - 1;
                
                if (vie == 0)
                {

                    this.Controls.Remove(panelenigme);
                    
                    this.Controls.Add(panelgameover);
                    
                    this.Size = new Size(1000, 600);
                    
                    panelgameover.Location = new Point(64, 31);
                    
                    panelgameover.Size = new Size(this.Width, this.Height);
                    
                    picturegameover.Size = new Size(this.Width, this.Height);
                    
                    
                    // game_over();
                    string txt = "point:" + " " + Score.ToString();
                    
                    recapitulatif.Text = txt.ToString();


                }
                
                    labelsecondchance.Visible = false;

            }


        }
        




        public void timerstop() {

            timesearch11.Stop();
     
        } 





        private void Timesearch11(object sender, EventArgs e)
        {
            reducesecond(1);
           
            labeltimersearch.Text = stringTime().ToString();
      
        }

        private void askQuestion(int s)
        {
            switch (s)
            {
                case 1:
                    pictureBox1.Image = Properties.Resources.John_F__Kennedy__White_House_photo_portrait__looking_up;
                    labelquestion.Text = "Dans quelle ville John kenedy a été assassiné ?";
                    but1.Text = "Dallas";
                    but2.Text = "Brooklyn";
                    but3.Text = "Denver";
                    but4.Text = "Manhattan";
                    correctAnswer = 1;
                    // pictureTrue.Visible = true;
                    break;


                case 2:

                    pictureBox1.Image = Properties.Resources.tchernobyl_1200x765;
                    labelquestion.Text = " dans quel pays s'est déroulé la catastrophe de Tchernobyl?";
                    but1.Text = "Estonie";
                    but2.Text = "Ukraine";
                    but3.Text = "Pologne";
                    but4.Text = "Littuanie";
                    correctAnswer = 2;
                    break;


                case 3:

                    pictureBox1.Image = Properties.Resources.maxresdefault;
                    labelquestion.Text = "quand commença la première guerre mondiale?";
                    but1.Text = "1915";
                    but2.Text = "1913";
                    but3.Text = "1914";
                    but4.Text = "1916";
                    correctAnswer = 3;
                    break;


                case 4:
                    pictureBox1.Image = Properties.Resources.gaelfaye;
                    labelquestion.Text = " Quel/quelle artiste français chante le  titre :Lundi Mechant?";
                    but1.Text = "Gaêl Faye";
                    but2.Text = "Soprano";
                    but3.Text = "Gims";
                    but4.Text = "Louane";
                    correctAnswer = 1;
                    break;


                case 5:

                    pictureBox1.Image = Properties.Resources.gafa;

                    labelquestion.Text = "Gafa= google ,apple,facebook ,que signifie la 4 ème lettre?";

                    but1.Text = "Amazon";
                    but2.Text = "Asus";
                    but3.Text = "Alcatel";
                    but4.Text = "Alcatraz";

                    correctAnswer = 1;

                    break;

                case 6:

                    pictureBox1.Image = Properties.Resources.ironman;

                    labelquestion.Text = "What is the name of the main character from Iron Man?";

                    but1.Text = "Tony Stank";
                    but2.Text = "Tony Stark";
                    but3.Text = "Rody";
                    but4.Text = "Peter Quill";

                    correctAnswer = 2;

                    break;

                case 7:

                    pictureBox1.Image = Properties.Resources.kyotoProtocol;

                    labelquestion.Text = "Le protocole de Kyoto est une convention ......?";

                    but1.Text = " de guerre";
                    but2.Text = "de paix";
                    but3.Text = "d'économie ";
                    but4.Text = "du climat";

                    correctAnswer = 4;

                    break;

                case 8:

                    pictureBox1.Image = Properties.Resources.mvt_brownien;

                    labelquestion.Text = "Quel scientifique expliqua le mouvement brownien?";

                    but1.Text = "Thomas Edinson";
                    but2.Text = "John Bradley";
                    but3.Text = " Einstein";
                    but4.Text ="Isaac Newton";

                    correctAnswer = 3;

                    break;

                case 9:
                    pictureBox1.Image = Properties.Resources.bob_marley;

                    labelquestion.Text = "Quel legende a chanté ce single <<Could you be loved>>?";

                    but1.Text = "Bob Marley";
                    but2.Text = "Elvis ";
                    but3.Text = "Michael Jackson";
                    but4.Text = "Notorius Big";

                    correctAnswer = 1;

                    break;


                case 10:

                    pictureBox1.Image = Properties.Resources.mae_jeminson;

                    labelquestion.Text = "Quelle est la première femme de couleur à aller dans l'espace?";

                    but1.Text = "Dr Marie Ampère";
                    but2.Text = "Dr washington";
                    but3.Text = "Dr M.Jeminson";
                    but4.Text = "dr Mia Mendes";

                    correctAnswer = 3;

                    break;

                case 11:

                    pictureBox1.Image = Properties.Resources.equipebelge;

                    labelquestion.Text = "Quel est le rang de l'équipe nation belge de football?";

                    but1.Text = "5";
                    but2.Text = "10";
                    but3.Text = "1";
                    but4.Text = "7";

                    correctAnswer = 3;

                    break;

                case 12:
                    pictureBox1.Image = Properties.Resources.marie_curie;

                    labelquestion.Text = "Qui a gagné le prix Nobel en physique pour sa recherche sur la radioactivité?";

                    but1.Text = "Maria Carrey";
                    but2.Text = "Marie Otis";
                    but3.Text = "Marie Asly";
                    but4.Text = "Marie Curry";

                    correctAnswer = 4;

                    break;

            }

        }





        private void playToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var sound = new SoundPlayer(@"C:\Users\aliou\Music\Pirate-Love-Song-Black-Heart.wav");
            sound.Play();

        }





        private void stopToolStripMenuItem_Click(object sender, EventArgs e)
        {

            var sound = new SoundPlayer(@"C:\Users\aliou\Music\Pirate-Love-Song-Black-Heart.wav");
            sound.Stop();


        }





        private void button1_Click_1(object sender, EventArgs e)
        {

            butStart();

        }





        public void butStart()
        {

            if (MessageBox.Show("Etes vous prêt", "Start", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                
                
                this.Controls.Remove(panelacceuil);

               
                this.Controls.Add(panelenigme);
              
                askQuestion(Random());
               
                this.Size = new Size(500, 600);
                
                panelenigme.Location = new Point(64, 31);
                
                panelenigme.Size = new Size(this.Width, this.Height);
                
                panel1.Size = new Size(this.Width, this.Height);


            }

        }
      
        
        
        
        
        
        //valeur permettant le random
        private int joke;
        public int previousvalue = -1;
        //public int valuerandom;  
        private int value ;


        

      //  public List<int> stockagevaleur = new List<int>();
        
       
        //on stocke 
        
        //methode qui permet d'afficher une question qui n'est pas la même que la précedente
        //on stocke  la valeur random  dans une liste  qui a été creer dans  "public lourd {initializecomponement}"
        //si la valurandom == stockage[i] cvd qu'on doit regenerer une nouvelle valeur 

        public int Random()
        {
            int values = 0;
            int valuerandom;
        
            
           Random r = new Random();
          


          

                valuerandom = r.Next(1, 13);



           // for(int j = 0;j < stockagevaleur.Count;j++)
                foreach (var plat in stockagevaleur)
                {
                bool intersection = true;
                while (intersection)
                {

                    intersection = false;
                    if (valuerandom == plat)
                    {
                        intersection = true;
                        valuerandom = r.Next(1, 13);
                        
                    }
                   

                }
                  
               
            }
            stockagevaleur[callrandom] = valuerandom   ;
            //**vérification des valeurs   de la liste 
            int a=  stockagevaleur[0];
            int b=stockagevaleur[1];
            int c =  stockagevaleur[2];
            int d = stockagevaleur[3];
            int e=stockagevaleur[4];


             return stockagevaleur[callrandom];
        }




  
        
       //panel d'acceuil où il y a le button start
        private void panelacceuil_Paint(object sender, PaintEventArgs e)
        {
            this.Controls.Remove(panelenigme);
          
            this.Controls.Add(panelacceuil);
           
            this.Controls.Remove(tableLayoutPanel1);

            
            int taillform1Width = 900;
           
            int tailleform1Height = 400;
            
            this.Size = new Size(1000, 800);
            
            panelacceuil.Location = new Point(64, 31);
            
            panelacceuil.Size = new Size(this.Width, this.Height); ;
            
            pictureboxdepart.Size = new Size(taillform1Width, tailleform1Height);

      
        }
      




        //methode permettant de calculer la distance du tag1 et la distance du tag2 et leur difference, il retourne la valeur result
        public double mover()
        {
                double distanceA = valueredifinitiondistancetag1X;
              
                double distanceB = valueredifinitiondistancetag2X;
                
                double distanceresult = distanceA - distanceB;
                
                resultvalue = Math.Abs(distanceresult);
              //  labelmessageform3.Text = distanceresult.ToString();

            return resultvalue;
        }





        //valeur entiere permettant l'incrementation des cibles
        public   int n = 1;
        private void checkdistance_Click(object sender, EventArgs e)
        {
            

        }





       
        




        //valeur utilisée dans l'evenement qui permet de savoir à quelle distance se trouve le deuxieme tag
        double maxvalue = 300;
        double minvalue = 10;
        double middlevalue = 100;
        private void nextquestion_Click(object sender, EventArgs e)
        {
            if (mover() >= maxvalue)
            {

                string a = "vous êtes trop loin de la cible";
                labelmessageform3.Text = a.ToString();

            }


            if (mover() > middlevalue && mover() < maxvalue)
            {

                string a = "vous vous eloingnez du tresor";
                labelmessageform3.Text = a.ToString();

            }

          
            if (mover() > minvalue && mover() <= middlevalue)
            {

                string q = "Fouillez encore , le tresor n'est pas très loin";
                labelmessageform3.Text = q.ToString();

            }


             if (mover() > 10 && mover() <= 40)
            {

                string q = "reflechissez car le tresor est juste à côté";
                labelmessageform3.Text = q.ToString();
           
            }
             
            
            
            
                     else if( mover()<minvalue)
                            {
                                     Score += 5;
                                     labelmessageform3.Text = Score.ToString();
                                     timerstop();
               
                                      //labeltimersearch.Text = second.ToString();
                
                
                                        if (MessageBox.Show(" le" + " " + (n) + " " + "tresor a été trouvé . Voulez vous continuer", "Felicitation", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk) == DialogResult.No)
                                           {

                   
                                                        Application.Exit();
                                                        
                                                        Environment.Exit(1);

                                            }
                                             
                                           else
                                               {
                                               
                                                   //***reinitialisation de tag2 ****

                                                  
                                                    tag2 = T((n));
                                      
                                                    if(n>4){
                                                                
                                                            //avant if(n==3)
                       
                                                              if (MessageBox.Show(" jeu terminer. Votre score est de "+""+labelmessageform3.Text +" points","Felicitation ", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
                                                                {

                                                                       Application.Exit();
                          
                                                                       Environment.Exit(1);
                
                                                                }
                                            
                                                                 else {
                            
                                                                        Application.Restart();
                                                                             
                                                                        Environment.Exit(0);
                       
                                                                       }


                                                            }
                                                                 callrandom++;
                                                                  
                                                                   this.Controls.Remove(panelsearch);
                                                                
                                                                
                                                                askQuestion(Random());
                                                                 
                                                                  
                                                                  this.Controls.Add(panelenigme);

                                                           }
               
                n++;

                    }
        }
       
       
        


        //minuteur

        public static int seconde = 300 ;
       
        public void reducesecond(int s)
        {
            seconde -= s;
           
            if (seconde == 0)
            {

                if (MessageBox.Show("Temps écoulé, voulez vous recommencez", "Time elapse", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    Application.Restart();
                    Environment.Exit(0);
                }
                else {
                    Application.Exit();

                    Environment.Exit(1);
                }

                    this.Controls.Add(panelgameover);
                    
                    this.Controls.Remove(panelsearch);
                    
                    this.Size = new Size(1000, 600);
                    
                    panelgameover.Location = new Point(64, 31);
                    
                    panelgameover.Size = new Size(this.Width, this.Height);
                    
                    picturegameover.Size = new Size(this.Width, this.Height);
                
                   

            }
        }
      
      
        


        //methode affichage minuteur

        public string stringTime()
        {

            int s, m;
            
            string time = "00:00";
            
            s = (seconde % 60);
            
            time = s.ToString();
           
            m = (seconde / 60) % 60;
            
            time = m.ToString() + ":" + s.ToString();
            
            return time;
        
        }


      

        //evenement permettant de recommencer (GAME Over)
        private void button1_Click_2(object sender, EventArgs e)
        {
           
            Application.Restart();
            
            Environment.Exit(1);
            
        }





        //evenement exit:
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
           
            Environment.Exit(1);

        }
   
    
    
    
    
    }
}









