namespace Project1Array
{
    class Program
    {
        static void Main(string[] args)
        {
            var watch = new System.Diagnostics.Stopwatch();
            watch.Start();
            for(int i = 0; i < 1000000; i++)
            {
                process[] pcbTimed = new process[10];
                process OSTimed = new process(350);
                process firstTimed = new process(1);
                process secondTimed = new process(2);
                process thirdTimed = new process(3);
                process fourthTimed = new process(4);
            
                firstTimed.setParent(OSTimed.getID());firstTimed.addChild(secondTimed.getID());firstTimed.addChild(thirdTimed.getID());
                secondTimed.setParent(firstTimed.getID()); secondTimed.setYoung(thirdTimed.getID()); secondTimed.setOld(0);
                thirdTimed.setParent(firstTimed.getID()); thirdTimed.setOld(secondTimed.getID()); thirdTimed.setYoung(0);
                fourthTimed.setParent(OSTimed.getID()); fourthTimed.setOld(0);

                pcbTimed[0] = firstTimed;
                pcbTimed[1] = secondTimed;
                pcbTimed[2] = thirdTimed;
                pcbTimed[3] = fourthTimed;
               
                try{
                     thirdTimed.destroy(pcbTimed);
                }
                catch
                {
                    
                }
                   
                
             
                
                    
                
            }
            watch.Stop();

            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
         
            Console.WriteLine("***If a 0 shows in output that means the value is null. If a 350 appears in output that is because I chose 350 as the OS process ID.***");
            process[] pcb = new process[10];
                process OS = new process(350);
                process first = new process(1);
                process second = new process(2);
                process third = new process(3);
                process fourth = new process(4);
            
                first.setParent(OS.getID());first.addChild(second.getID());first.addChild(third.getID());
                second.setParent(first.getID()); second.setYoung(third.getID()); second.setOld(0);
                third.setParent(first.getID()); third.setOld(second.getID()); third.setYoung(0);
                fourth.setParent(OS.getID()); fourth.setOld(0);

                pcb[0] = first;
                pcb[1] = second;
                pcb[2] = third;
                pcb[3] = fourth;
            
            try
            {
                displayPCB(pcb);
            }
            catch (Exception e)
            {
                Console.WriteLine("");
            }
            try
            {
                third.destroy(pcb);
         }
            catch (Exception e)
            {
                
            }
            Console.WriteLine("********** PCB after Destroying process 3 **********");
            try
            {
                displayPCB(pcb);
            }
            catch (Exception e)
            {
                Console.WriteLine("");
            }
        }
        public static void displayPCB(process[] pcb)
        {
            for(int i = 0; i <= pcb.Length; i++)
            {
                if(pcb[i] != null)
                {
                    pcb[i].display();
                }

            }
        }

        public class process
        {
            int pid;
            int parent;
            int[] children = new int[10];
            int older_sibling;
            int younger_sibling;
            public process(int id)
            {
                this.pid = id;
            }

            public void destroy(process[] processes)
            {
                int tempParent = this.getParent();
                int tempYoung = this.getYounger();
                int tempOld = this.getOlder();
                int[] child = this.getChild();
                int tempProcess;

                for(int i = 0; i <= processes.Length; i++)
                {
                    for(int a = 0; a < child.Length; a++)
                    {
                        if(child[a] == processes[i].getID())
                        {
                            processes[i] = null;
                        }
                    }

                    if(this.getOlder() != 0)
                    {
                        this.setOld(0);
                    }
                    if(this.getYounger() != 0)
                    {
                        this.setYoung(0);
                    }
                    if(this.getParent() != 350)
                    {
                        this.setParent(0);
                    }
                    if(processes[i].getOlder() == this.getID())
                    {
                        processes[i].setOld(0);
                    }
                    if(processes[i].getYounger() == this.getID())
                    {
                        processes[i].setYoung(0);
                    }
                    tempProcess = processes[i].getID();
                    if(tempProcess == this.getID())
                    { 

                        processes[i] = null;
                    }

                }
            }
            public int getID()
            {
                return this.pid;
            }
            public int getParent()
            {
                return this.parent;
            }
            public int getYounger()
            {
                return this.younger_sibling;
            }
            public int getOlder()
            {
                return this.pid;
            }
            public int[] getChild()
            {
                return this.children;
            }

            public void setParent(int ppid)
            {
                this.parent = ppid;
            }
            public void setYoung(int ypid)
            {
                this.younger_sibling = ypid;
            }
            public void setOld(int opid)
            {
                this.older_sibling = opid;
            }
            public void addChild(int childPID)
            {
                children.Append(childPID);
            }
            public void setChildren(int[] childrenPID)
            {
                for(int i = 0;i <= childrenPID.Length; i++)
                {
                    children[i] = childrenPID[i];
                }
            }

            public void display()
            {
                Console.WriteLine("My PID is " + this.pid + ", my parent is " + this.parent + ", siblings are " + this.older_sibling + " " + younger_sibling);
            }
        }


    }
}