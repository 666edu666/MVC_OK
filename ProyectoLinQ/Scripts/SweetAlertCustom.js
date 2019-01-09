$(document).ready(function () {
    $("#delete").click(function () {
        e.preventDefault();
        swal({
            title: '<strong>¿Estás seguro de eliminar al doctor?</strong>',
            type: 'info',
            html:
                'Pulsa  <b>borrar</b> para confirmar',
            showCloseButton: true,
            showCancelButton: true,
            focusConfirm: false,
            confirmButtonText: '<i class= fas fa-igloo"></i> Borrar!',
            confirmButtonAriaLabel: 'Doctor BORRADO',
            cancelButtonText:
                '<i class="fas fa-undo-alt"></i>',
            cancelButtonAriaLabel: 'Doctor NO BORRADO',
        }).then(function (result) {
            $('#myForm').submit();
        });
        alert("Borrar");
    })
})