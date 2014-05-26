//Copyright (C) 2014 AlexVictorne, Nikita_blackbeard

using System.Threading;

namespace controlPrg
{
    class myThread
    {
        Thread thread;
        Sampletor_Form sf;
        public myThread(string name, int num, Sampletor_Form f1) //Конструктор получает имя функции и номер до кторого ведется счет
        {
            this.sf= f1;
            thread = new Thread(this.func);
            thread.Name = name;
            thread.Start(num);//передача параметра в поток
        }

        void func(object num)
        {
            sf.ImagesFromDirectoryToTXT(thread.Name);
        }


    }
}