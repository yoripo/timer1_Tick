namespace timer1_Tick
{
    public partial class Form1 : Form
    {
        CancellationTokenSource cts = new CancellationTokenSource();

        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // �{�^���𖳌��ɂ���
            button2.Enabled = false;

            // �^�C�}�[���J�n����
            timer1.Interval = 5000; // 5�b
            timer1.Start();

            // �ʐM�������J�n����
            // ...
            try
            {
                await new Class1().Run(cts.Token);
                MessageBox.Show("�ʐMOK");
            }
            catch (OperationCanceledException)
            {
                // �^�C���A�E�g�ɂ�菈�����L�����Z�����ꂽ�ꍇ
                MessageBox.Show("���\�������̂�");
            }
        }

        internal class Class1
        {
            public async Task Run(CancellationToken token)
            {
                MessageBox.Show("��������҂��܂�");
                //��b�ԁi1000�~���b�j��~����
                await Task.Delay(10000, token);

                MessageBox.Show("�����ʂ�Ȃ�");
            }
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            // �^�C�}�[���~����
            timer1.Stop();

            // �{�^����L���ɂ���
            button2.Enabled = true;

            // �G���[���b�Z�[�W��\������
            MessageBox.Show("�ʐM���^�C���A�E�g���܂����B", "�G���[", MessageBoxButtons.OK, MessageBoxIcon.Error);

            // �������L�����Z������
            cts.Cancel();

            // �������I������
            return;
        }
    }
}