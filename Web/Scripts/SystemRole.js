function SelectSubItems(id)
{
   var obj=document.getElementById(id);
   var objs=document.getElementById("ul_"+id).getElementsByTagName("input");
   for(var i=0;i<objs.length;i++)
   {
      if(objs[i].type.toLowerCase()=="checkbox")
         objs[i].checked=obj.checked;
   }
}

function CheckSubItems(id)
{
   var parentObj=document.getElementById(id);
   var objs=document.getElementById("ul_"+id).getElementsByTagName("input");
   var hasCheckedChild=false;
   for(var i=0;i<objs.length;i++)
   {
      if(objs[i].type.toLowerCase()=="checkbox")
      {
         if(objs[i].checked)
         {
            hasCheckedChild=true;
            break;
         }
      }
   }
   parentObj.checked=hasCheckedChild;
}