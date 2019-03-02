using System;

namespace Std{
    class Human{
        public int legs = 2;
        public int arms = 2;
        public int head = 1;
    }

    class Dweller : Human{
        public string name;
        public int age;
        public string gender;

        public string GetName{
            get{
                return name;
            }
            set{
                if(value == ""){
                    name = "No name";
                }else{
                    name = value;
                }
            }
        }

        public int GetAge{
            get{
                return age;
            }
            set{
                if(value < 0){
                    age = 0;
                }else if(value > 150){
                    age = 150;
                }else{
                    age = value;
                }
            }
        }

        public string GetGen{
            get{
                return gender;
            }
            set{
                if(value != "male" || value != "female"){
                    gender = "male";
                }else{
                    gender = value;
                }
            }
        }

        public Dweller(string name, int age, string gender){
            GetName = name;
            GetAge = age;
            GetGen = gender;
        }

        public void Show(){
            Console.WriteLine(GetName + " " + GetAge + " " + GetGen);
        }
    }

    class Major : Dweller{
        public Major(string name, int age, string gender) : base(name, age, gender){

        }
        public void Order(string order){
            Console.WriteLine(order);
        }
    }

    class Worker : Dweller{
        public Worker(string name, int age, string gender) : base(name, age, gender){

        }
        public void Work(){
            Console.WriteLine("I am working");
        }
    }

    class Building{
        int area;
        string shape;

        public Building(int _area, string _shape){
            area = _area;
            shape = _shape;
        }

        public void Show(){
            Console.WriteLine(area + " " + shape);
        }
    }

    class Program{
        static void Main(){
            Worker d1 = new Worker("Berik", 18, "male");
            Major m1 = new Major("Anton", 23, "male");
            Dweller d3 = new Dweller("Anna", 18, "female");
            Building b1 = new Building(200, "square");
            Dweller d2 = new Dweller("", -10, "asass");
            // d3.Show();
            // b1.Show();
            m1.Order("Work");
            m1.Show();
            // Console.WriteLine(m1.arms);
            d1.Work();
            d2.Show();
        }
    }
}