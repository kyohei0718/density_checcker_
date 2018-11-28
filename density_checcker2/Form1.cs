using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static density_checcker2.octree;
using System.Timers;
using System.Runtime.CompilerServices;

namespace density_checcker2
{
    public partial class Form1 : Form
    {
        string line = "";
        List<string> list = new List<string>();
        public static Counting count = new Counting();
        CycleMeasurementMemory _hoge;
        private point3D rootpoint = new point3D();
        public static double check_area = 100000;
        public long maxmemory;

        public Form1()
        {
            InitializeComponent();
            _hoge = new CycleMeasurementMemory(this);
        }

        private void 開くOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dr = openFileDialog1.ShowDialog();
            if (dr == System.Windows.Forms.DialogResult.OK)
                for (int i = 0; i < openFileDialog1.FileNames.Length; i++)
                {
                    ReadFile.Text += openFileDialog1.FileNames[i];
                    list.Add(openFileDialog1.FileNames[i]);
                }
        }

        private void exe_Click(object sender, EventArgs e)
        {
            var counter = new CycleMeasurementMemory(this);
            counter.Start(TimeSpan.FromMilliseconds(1000)); // 1秒間隔で計測実行
            octree.boxelsize = double.Parse(splitsize.Text)/1000;
            //Console.WriteLine("Start!");
            localconsole.Text = "Start!\r\n";
            localconsole.Update();
            var sw = new System.Diagnostics.Stopwatch();
            sw.Restart();
            long usememory = Environment.WorkingSet;

            Node root = new Node();
            point3D readpoint = new point3D();
            var Octree = new octree();


            foreach (string st in list)
            {
                using (StreamReader sr = new StreamReader(st, Encoding.GetEncoding("Shift_JIS")))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] splitted = line.Split(',');
                        try
                        {
                            octree.cp.X = float.Parse(splitted[1]);
                            octree.cp.Y = float.Parse(splitted[0]);
                            octree.cp.Z = float.Parse(splitted[2]);
                            Octree.PointWrite(root, check_area);
                            if (maxmemory < Environment.WorkingSet) maxmemory = Environment.WorkingSet;
                        }
                        catch (Exception error)
                        {
                            continue;
                        }
                    }
                }
            }
            //Console.WriteLine("読み込み終了");
            localconsole.Text += "読み込み終了\r\n";
            localconsole.Update();

            Encoding sjisEnc = Encoding.GetEncoding("Shift_JIS");
            using (StreamWriter writer = new StreamWriter(@"C:\test\"+WriteFile.Text, true, sjisEnc))
            {
                Octree.PointRead(root,writer,rootpoint);
            }
            sw.Stop();
            pointmax.Text = Form1.count.mpoint.ToString();
            pointaverage.Text = Form1.count.average.ToString();
            exetime.Text = sw.Elapsed.ToString();
            //Console.WriteLine("書き出し終了");
            localconsole.Text += "書き出し終了\r\n";
            localconsole.Update();
            counter.Stop();
            //Console.WriteLine("UseMemory:" + maxmemory);
            memory.Text =  maxmemory.ToString() ;
            //Console.WriteLine("Finished! Time:" + sw.Elapsed);
            localconsole.Text += "Finished!\r\n";
            localconsole.Update();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            ReadFile.Text = "";
            WriteFile.Text = "";
            splitsize.Text = "";
            pointmax.Text = "";
            pointaverage.Text = "";
            memory.Text = "";
            exetime.Text = "";
            localconsole.Text = "";
        }

        public void memoryupdate(long usememory)
        {
            memory.Text = usememory+"byte";
            memory.Update();
            Console.WriteLine(usememory + "byte");
        }
    }

    /// <summary>
    /// 現在のメモリ使用状況を一定時間ごとに取得するクラス
    /// </summary>
    public class CycleMeasurementMemory : IDisposable
    {

        //
        // Fields
        // - - - - - - - - - - - - - - - - - - -

        /// <summary>通知先のハンドラ</summary>
        private Action<object, EventArgs> _elapsed;
        /// <summary>計測用の定周期タイマー</summary>
        private System.Timers.Timer timer;

        /// <summary>
        /// 一定時間ごとに呼ばれるメモリ使用量通知イベント
        /// </summary>
        public Action<object, EventArgs> Elaplsed
        {
            set
            {
                ArgumentUtility.NullCheck(value);
                this._elapsed = value;
            }
            get { return this._elapsed; }
        }

        //
        // Constructors
        // - - - - - - - - - - - - - - - - - - -

        /// <summary>
        /// 既定の初期値でオブジェクトを初期化します。
        /// </summary>

        Form1 _form1;
        
        public CycleMeasurementMemory(Form1 form1)
        {
            _form1 = form1;
            // デフォルトの出力先を設定する
            _elapsed = (object o, EventArgs e) => {
                Console.WriteLine(Environment.WorkingSet + "byte");
                Huga();
            };
        }

        public void Huga()
        {
            _form1.memoryupdate(Environment.WorkingSet);
        }

        //
        // Public Methods
        // - - - - - - - - - - - - - - - - - - -

        /// <summary>
        /// 計測間隔を指定してメモリの測定を開始します。
        /// 10ミリ秒以下は指定できません。
        /// </summary>
        public void Start(TimeSpan interval)
        {
            if (interval < TimeSpan.FromMilliseconds(10))
            {
                throw new ArgumentOutOfRangeException(
                    "interval", "Can not specify less than 10 milli second.");
            }
            if (this.timer != null)
            {
                return; // 測定中の再スタートは無視
            }
            this.timer = new System.Timers.Timer(interval.TotalMilliseconds);
            this.timer.Elapsed += timer_Elapsed;
            this.timer.Start();
        }

        /// <summary>
        /// 計測を中止します。
        /// </summary>
        public void Stop()
        {
            using (this.timer) { }
            this.timer = null;
        }

        /// <summary>
        /// IDisposableの実装 - オブジェクト使用している資源を解放します。
        /// </summary>
        public void Dispose()
        {
            using (this.timer) { }
            this._elapsed = null;
        }

        /// <summary>
        /// メモリ使用量を計測します。
        /// </summary>
        public static MemoryEventArgs Measurement()
        {
            return new MemoryEventArgs(DateTime.Now, Environment.WorkingSet);
        }

        //
        // Private Methods
        // - - - - - - - - - - - - - - - - - - -

        /// <summary>
        /// メモリを計測します。
        /// </summary>
        private void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            this.timer.Stop();
            this._elapsed(this, Measurement());
            this.timer.Start();
        }
    }

    /// <summary>
    /// メモリ通知イベントで使用するイベントオブジェクト
    /// </summary>
    public class MemoryEventArgs : EventArgs
    {

        //
        // Properties
        // - - - - - - - - - - - - - - - - - - -

        /// <summary>
        /// 計測時刻を取得します。
        /// </summary>
        public DateTime Time { get; private set; }

        /// <summary>
        /// 計測時のメモリ使用量を取得します。
        /// </summary>
        public long WorkingSet { get; private set; }

        //
        // Constructors
        // - - - - - - - - - - - - - - - - - - -

        /// <summary>
        /// 計測時刻とメモリ使用量を指定してオブジェクトを初期化します。
        /// </summary>
        public MemoryEventArgs(DateTime time, long workingSet)
        {
            this.Time = time;
            this.WorkingSet = workingSet;
        }
    }

    /// <summary>
    /// 汎用引数チェック機能を提供するクラス
    /// </summary>
    public static class ArgumentUtility
    {

        /// <summary>
        /// オブジェクトがnullかどうか確認し、nullの場合例外を発生させます。
        /// </summary>
        public static void NullCheck(object o, [CallerMemberName]string calledBy = "")
        {
            if (o == null) { throw new ArgumentNullException(calledBy); }
        }
    }
}
