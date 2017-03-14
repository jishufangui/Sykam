
   function CheckChange1()
    {
       var objs=document.getElementsByTagName("input");
       var obj=document.getElementById("chkAll");
       
       for(var i=0;i<objs.length;i++)
       {
           if(objs[i].type.toLowerCase()=="checkbox")
               objs[i].checked=obj.checked;
       }
    }
    
       function CheckChange(state)
    {
       var objs=document.getElementsByTagName("input");
       
       for(var i=0;i<objs.length;i++)
       {
           if(objs[i].type.toLowerCase()=="checkbox")
               objs[i].checked=state;
       }
    }
