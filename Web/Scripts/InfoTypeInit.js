jQuery(function(){
   var holder=$("#typeHolder");
   var topSel=$("#topSelc");
   
   CheckIsTop();
   $.ajax({
      type:"POST",
      url:"ajax/GetInfoCate.aspx",
      data:{"uid":0,"sv":0},
      success:function(res){
         if(res!="0")
         {
            topSel.html(res);
         }
      }
   });
});

function SelectedIndexChanged(obj)
{
    var val=$(obj).val();
    if(val!="0")
    {
      $.ajax({
       type:"POST",
       url:"ajax/GetInfoCate.aspx",
       data:{"uid":val,"sv":0},
       success:function(res){
          RemoveSelectNode(obj);
          if(res!="0")
          {
              var node=$(obj).clone(true);
              node.html(res);
              node.insertAfter($(obj));
          }
             
        }
      });
    }
    else
    {
        RemoveSelectNode(obj);
    }
}

function RemoveSelectNode(obj)
{
    var holder=document.getElementById("typeHolder");
    var objs=holder.getElementsByTagName("select");

        if(holder)
        {
            var j = 0;
            var n = objs.length;
            for(var i = 0; i < n ;i++)
            {
                if(objs[i]==obj)
                {
                   j=i+1;
                   break;
                }
            }
            
            for(var k = j; k < n; k++)
                holder.removeChild(objs[j]);
        }
}

function CheckIsTop()
{
   var holder=document.getElementById("typeHolder");
   var isTop=document.getElementById("cbx_IsTop");
   var objs=holder.getElementsByTagName("select");
   if(isTop)
   {
      var disabled=isTop.checked;
   
      for(var i=0;i<objs.length;i++)
         objs[i].disabled=disabled;
   }
}
