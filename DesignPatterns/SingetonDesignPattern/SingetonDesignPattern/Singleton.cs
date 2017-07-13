using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SingetonDesignPattern
{
   //// ////eager intializtion of singleton pattern
   //// public class Singleton
   //// {
   ////     private static Singleton instance = new Singleton();
   ////     private Singleton()
   ////     {
   ////     }
   ////     public static Singleton GetInstance
   ////     {
   ////         get
   ////         {
   ////             return instance;
   ////         }
   ////     }
   //// }

   ////////lazy initialization of singleton
   //// public class Singleton
   ////     {
   ////         private static Singleton instance = null;
   ////         private Singleton()
   ////         {
   ////         }
   ////         public static Singleton GetInstance
   ////             {
   ////                 get
   ////                 { 
   ////                     if (instance == null)
   ////                         instance = new Singleton();
   ////                     return instance;
   ////                  } 
   ////             }
   ////     }

    ////Thread-safe (Double-checked Locking) initialization of singleton

    public class Singleton
    {
        private static Singleton instance = null;
        private Singleton()
        {
        }
        private static object lockThis = new object();

        public static Singleton GetInstance
        {
            get
            {
                lock (lockThis)
                {
                    if (instance == null)
                        instance = new Singleton();

                    return instance;
                }
            }
        }
    }

 
}
