using System;
using System.IO;

namespace Std{      // Эта программа "создает" деревню с жителями и инфраструктурой
    class Human{    // Каждый житель - человек. Класс человек - родительский класс для всех дителей
        public int legs = 2; // У каждого человека 2 руки, 2 ноги и одна голова
        public int arms = 2;
        public int head = 1;
    }

    class Dweller : Human{ // Класс Dweller, жителей деревни, наследуется от Human, так как все жители деревни люди
        public string name; // У каждого жителя есть своё имя, возраст, пол
        public int age;
        public string gender;

        public string GetName{ // Для того, чтобы не были введены неправильные данные в поля Dweller используется СВОЙСТВО(Propery)
            get{
                return name;
            }
            set{
                if(value == ""){ // Если введена пустая строка вместо имени - имя назначается по стандарту "No name"
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
                if(value < 0){ // Если возраст меньше 0 или больше 150, то работает проверка
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
                if(value != "male" || value != "female"){ // Если введенный пол ни мужской, ни женский, то пристваевается по умолчанию "male"
                    gender = "male";
                }else{
                    gender = value;
                }
            }
        }

        public Dweller(string name, int age, string gender){  // Конструктор Dweller, принимающий 3 аргумента и назначающий 
            GetName = name;                                   // значение на свойства
            GetAge = age;
            GetGen = gender;
        }

        public void Show(){ // Выводит всю информацию о жителе
            Console.WriteLine(GetName + " " + GetAge + " " + GetGen);
        }
    }

    class Major : Dweller{ // Мэр - тоже житель, а значит у него есть тоже имя, возраст, пол (Наследуется от Dweller)
        public Major(string name, int age, string gender) : base(name, age, gender){ // Конструктор Major передает полученные 
                                                                                    // значение в конструктор Dweller
        }   
        public void Order(string order){ // Выводит в консоль приказ
            Console.WriteLine(order);
        }
    }

    class Worker : Dweller{ // Рабочий - житель. Аналогично мэру имеет имя, возраст, пол
        public Worker(string name, int age, string gender) : base(name, age, gender){ // Происходит то же самое, что и в конструкторе Major

        }
        public void Work(){ 
            Console.WriteLine("I am working");
        }
    }

    class Police : Dweller{ // Полицейский - житель
        public Police(string name, int age, string gender) : base(name, age, gender){
            
        }

        public void Arrest(Dweller dw){ // Принимает агрументом жителя, которого нужно арестовать
            Console.WriteLine("Dweller " + dw.name + " was arrested"); // Выводит имя арестанта
        }
    }

    class Judge : Dweller{ // Тоже житель
        public Judge(string name, int age, string gender) : base(name, age, gender){

        }

        public void CreateLaw(string lawText){ // Метод добавляет в файл "laws.txt" новый закон, переданные агрументом
            using(StreamWriter writeLaw = new StreamWriter(@"C:\Users\Kirill\Desktop\village\laws.txt", true)){ // Поток для записи с append true
                writeLaw.WriteLine(lawText);
            }
        }

        public void ShowLaws(){ // Метод для вывода всех законов в консоль
            using(StreamReader readLaws = new StreamReader(@"C:\Users\Kirill\Desktop\village\laws.txt")){ // Поток для чтения
                Console.WriteLine(readLaws.ReadToEnd());
            }
        }

        public void DeleteLaws(){ // Удаление всех текущих законов
            using(StreamWriter sw = new StreamWriter("laws.txt")){
                sw.WriteLine(); 
            }
        }
    }

    class Building{ // Класс для всех зданий в деревне
        int area;
        string shape;

        public Building(int _area, string _shape){
            area = _area;
            shape = _shape;
        }

        public void Show(){
            Console.WriteLine(area + " " + shape);
        }

        public void CreateHouses(string nameOfHouse){ // При вызове метода создается папка "Houses" и в нее добаляется файл, с названиеи
            DirectoryInfo dir = new DirectoryInfo("Houses"); // полученным в качестве агрумента
            if(dir.Exists == true){
                FileInfo file = new FileInfo(@"Houses\" + nameOfHouse + ".txt");
                if(file.Exists == true){
                    
                }else{
                    file.Create();
                }
            }else{
                dir.Create();
            }
        }
    }

    class Program{
        static void Main(){
            Worker d1 = new Worker("Berik", 18, "male");
            Major m1 = new Major("Anton", 23, "male");
            Dweller d3 = new Dweller("Anna", 18, "female");
            Building b1 = new Building(200, "square");
            Dweller d2 = new Dweller("", -10, "asass");
            Judge j1 = new Judge("Anton", 23, "male");
            m1.Order("Work"); 
            d1.Work();
            d2.Show();
            j1.CreateLaw("Wake up at 5 AM");
            j1.CreateLaw("Do not watch TV");
            j1.ShowLaws();
            //j1.DeleteLaws(); 
            b1.CreateHouses("Hoiuse111");
        }
    }
}