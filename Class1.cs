namespace TestWpfFluentValidation
{
   public class Class1
    {
       public string regEx { get; set; }

       public Class1()
       {
           regEx =  @"^\d{5}(?:[-\s]\d{4})?$";
       }

    }
}
