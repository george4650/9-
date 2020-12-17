 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lib_15
{
    public struct Factory
    {
        
        int downtime, // время простоя в минутах
            worktime; // время работы в минутах
        // Время простоя, и время работы считается во время рабочей смены (когда фабрика не работает время простоя не увеличивается)
        // тогда имеем 40-часовую рабочую неделю, значит 160 часов рабочих часов в месяце
        // тогда время простоя + время работы (всё это в минутах) = 160*60 = 9600

        // конструктор
        public Factory(string name, int downtime)
        {
            ToolName = name;
            if(downtime<9600)
            {
                this.downtime = downtime;
                worktime = 9600 - downtime;
            }
            else
            {
                this.downtime = 600;
                worktime = 9000;
                MessageBox.Show($"Время простоя за месяц не может превышать количество минут в рабочих сменах за месяц (9600)." +
                    "\nСтруктуре будут заданы параметры по умолчанию(кроме имени): \nНазвание станка: " + name + " \nВремя простоя: " + downtime + "\nВремя работы: " + worktime);
            }
        }
        // время простоя за месяц
        public int DowntimePerMonth
        {
            get
            {
                return downtime;
            }
        }
        // время работы за месяц
        public int WorktimePerMonth
        {
            get
            {
                return worktime;
            }
        }
        // название станка
        public string ToolName { get; set; }

        // просто для удобства вывода в листбокс
        public string GetString()
        {
            string str = "Название станка: " + ToolName + " Время простоя: " + downtime + " Время работы: " + worktime;
            return str;
        }

    }
}
