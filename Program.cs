namespace Project1LL
{
    
    class Program
    {
        static void Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            
            watch.Start();
            for(int i = 0; i < 1000000; i++)
            {
                PCB OSTimed = new PCB(350);
                PCB firstTimed = new PCB(1);
                PCB secondTimed = new PCB(2);
                PCB thirdTimed = new PCB(3);
                PCB fourthTimed = new PCB(4);
                PCB[] processesTimed = new PCB[5];
                processesTimed[0] = firstTimed;processesTimed[1] = secondTimed;processesTimed[2] = thirdTimed;processesTimed[3] = fourthTimed;
                OSTimed.setParent(null);      OSTimed.addChild(firstTimed);     OSTimed.addChild(fourthTimed);
                firstTimed.setParent(OSTimed);     firstTimed.addChild(secondTimed); firstTimed.addChild(thirdTimed); 
                secondTimed.setParent(firstTimed); secondTimed.addChild(null);
                thirdTimed.setParent(firstTimed);  thirdTimed.addChild(null);
                fourthTimed.setParent(OSTimed); fourthTimed.addChild(null);
                thirdTimed.destroyProcess(processesTimed);
            }
            watch.Stop();

            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
            //PCB OS = new PCB(350);
            //PCB first = new PCB(1);
            //PCB second = new PCB(2);
            //PCB third = new PCB(3);
            //PCB fourth = new PCB(4);
            //PCB[] processes = new PCB[5];
            //processes[0] = first;processes[1] = second;processes[2] = third;processes[3] = fourth;
            //OS.setParent(null);      OS.addChild(first);     OS.addChild(fourth);
            //first.setParent(OS);     first.addChild(second); first.addChild(third); 
            //second.setParent(first); second.addChild(null);
            //third.setParent(first);  third.addChild(null);
            //fourth.setParent(OS); fourth.addChild(null);
            //third.destroyProcess(processes);
            //displayPCB(processes);
            //third.destroyProcess(processes);
            //Console.WriteLine("********** PCB after destroying process 3 **********");
            //displayPCB(processes);
        }

        public static void displayPCB(PCB[] thePCB)
        {
            for(int i = 0; i < thePCB.Length - 1; i++)
            {
                if(thePCB[i] != null)
                {
                    thePCB[i].display();
                }
                
            }
        }
        public class PCB
        {
            int ID;
            PCB next;
            PCB parent;
            LinkedList children = new LinkedList(null);

            
            public PCB(int a)
            {
                ID = a;
            }
            public void setNext(PCB nextNode)
            {
                this.next = nextNode;
            }
            public PCB getNextNode()
            {
                return this.next;
            }
            public int getID()
            {
                return this.ID;
            }
            public void setParent(PCB ProcessParent)
            {
                parent = ProcessParent;
            }
            public PCB getParent()
            {
                return this.parent;
            }
            public void addChild(PCB child)
            {
                if(children.getHead() == null)
                {
                    children.setHead(child);
                }
                else
                {
                    children.addChild(child);
                }
            }
            private void removeChildren()
            {
                this.children = null;
            }

            public void display()
            {
                if(this.parent != null)
                {
                    Console.WriteLine("I am process " + this.ID + " and my parent is " + this.parent.getID() + " and my children are: ");
                }
                else
                {
                    Console.WriteLine("I am process " + this.ID + " and i am a destroyed process");
                }
                if(this.children != null)
                {
                    this.children.displayChildren();
                }
                
            }

            public void destroyProcess(PCB[] array)
            {
                if(this.children != null)
                {
                    this.removeChildren();
                }
                for(int i = 0; i < array.Length-1; i++)
                {
                    if(array[i].getParent().getID() == this.ID) 
                    {
                        array[i].destroyProcess(array);
                    }
                }
                for(int i = 0; i < array.Length-1; i++)
                {
                    if(array[i].getID() == this.ID)
                    {
                        array[i] = null;
                    }
                }
                if(this.parent.children.getHead().getID() == this.ID)
                {
                   this.parent.children.setHead(this.parent.children.getHead().getNextNode());
                }
                else
                {
                     this.parent.children.getHead().setNext(this.parent.children.getHead().getNextNode().getNextNode());
                }
            }
        }
        public class LinkedList
        {
            PCB head;
            public LinkedList(PCB head)
            {
               this.head = head;
            }

            public void display()
            {
                PCB i = this.head;
                while(i != null)
                {
                    i.display();
                    i = i.getNextNode();
                }
            }
            public void displayChildren()
            {
            
                PCB i = this.head;
            
                
                if(i == null)
                {
                    Console.Write("  Process has no children...");
                }
                else
                {
                    while(i != null)
                    {
                        int tempID = i.getID();
                        Console.Write(tempID + " ");
                        i = i.getNextNode();
                    }

                }
                
                Console.WriteLine("");
            }
            public PCB getHead()
            {
                return this.head;
            }
            public void setHead(PCB first)
            {
                this.head = first;
            }

            public void addChild(PCB child)
            {
                if(this.head == null)
                {
                    this.head = child;
                }
                else
                {

                PCB i = this.head;
                PCB a = this.head;
                PCB newNode = child;
                while(a != null)
                {
                    a = i.getNextNode();
                    if(a == null)
                    {
                        i.setNext(newNode);
                    }
                    else
                    {
                        i = i.getNextNode();
                    }
                    
                }
                }
            }
        }
    }
}