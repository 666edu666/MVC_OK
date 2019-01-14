$(document).ready(function () {
    $("#botonenviar").click(function () {
        //DEBEMOS VALIDAR LA ENTRADA DEL USUARIO
        //DE DATOS                   
        var datos = $("#Nombre").val();
        //RECORREMOS TODAS LAS LETRAS DE LA CAJA
        var datosbuenos = "";
        for (var i = 0; i < datos.length; i++) {
            //CAPTURAMOS CADA LETRA
            var letra = datos.charAt(i);
            if (letra == "<") {
                letra = "&lt;";
            } else if (letra == ">") {
                letra = "&gt;";
            }
            datosbuenos += letra;
        }
        //CAMBIAMOS EL CONTENIDO DE LA CAJA
        //NORMALIZADO
        $("#Nombre").val(datosbuenos);
    });
}); 
