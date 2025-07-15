using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
namespace FishingGame
{
    //�������ö��
    public enum FishType {
        _None,
        _Shark,
        _Bigfish,
        _Smallfish
    }
    //ҧ���¼�����
    public class FishBitingEventArgs : EventArgs {
        public FishType FishType{ get; set; }
    }
    //ҧ�����ϵͳ
    public class BitingDetectionSystem
    {
        private readonly System.Random random = new System.Random();
        private CancellationTokenSource cancellationTokenSource;
        //ҧ���¼�
        public event EventHandler<FishBitingEventArgs> FishBiting;
        //��ʼ���ҧ��
        public void StartDetection()
        {
            Console.WriteLine("˦�˶�����ɣ�׼����ʼ���ҧ��...");
            //wait 1s
            Thread.Sleep(1000);
            Console.WriteLine("��ʼ���ҧ��...");

            cancellationTokenSource = new CancellationTokenSource();

            //ʹ���̳߳�ִ�ж�ʱ�������
            ThreadPool.QueueUserWorkItem(_ => PerformDetection(cancellationTokenSource.Token));
        }
        //stop detection
        public void StopDetection() {
            cancellationTokenSource?.Cancel();
            Console.WriteLine("ֹͣҧ�����");
        }
        //begin detection
        private void PerformDetection(CancellationToken cancellationToken) {
            while (!cancellationToken.IsCancellationRequested)
            {
                //one detect/0.2s
                Thread.Sleep(200);
                //����ҧ���ж�
                var result = DetermineFishBiting();
                if (result != FishType._None)
                {
                    //����ҧ���¼�
                    OnFishBiting(new FishBitingEventArgs { FishType = result });
                    break;
                }
            }
        }
        //�ж��Ƿ�����ҧ��
        private FishType DetermineFishBiting() {
            double randomValue = random.NextDouble();
            if (randomValue < 0.05)//0.05 shark
            {
                Console.WriteLine("��⵽����ҧ��������ȷ���������...");
                return FishType._Shark;
            }
            else if (randomValue < 0.15)//0.1 bigfish
            {
                Console.WriteLine("��⵽����ҧ��������ȷ���������...");
                return FishType._Bigfish;
            }
            else if (randomValue < 0.3)//0.15 small fish
            {
                Console.WriteLine("��⵽����ҧ��������ȷ���������...");
                return FishType._Smallfish;
            }
            Console.WriteLine("���μ��û����ҧ��");
            return FishType._None;
        }
        // ����ҧ���¼��ķ���
        protected virtual void OnFishBiting(FishBitingEventArgs e)
        {
            FishBiting?.Invoke(this, e);
        }
    }
}