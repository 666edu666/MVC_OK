$("input[type=radio]").change(function () {

    var data = { oficio: $("input[type=radio]:checked").val() };
    var data = "cadenaCliente";
    $.ajax({
        
        //data.Oficio = $("input[type=radio]:checked").val();
        method: "POST",
        url: '@Url.Action("CargaTabla")', //Llamada del método C# partiendo desde la ruta que acciona el GET
        data: data,
        success: function (d) {

            alert(d.success);
            
        },
        error: function (xhr, textStatus, errorThrown) {
            alert('Error!!');
        }
       
        
    });
    
});