function successNotif(txt) {
    $.notifyDefaults({
        type: 'success',
        allow_dismiss: false
    });
    $.notify(txt);
};
function errorNotif(txt) {
    $.notifyDefaults({
        type: 'danger',
        allow_dismiss: false
    });
    $.notify(txt);
};
$('.confirmDelete').click(function (e) {
    e.preventDefault();
    swal({
        title: "Êtes-vous sûr ?",
        text: "Une fois supprimer il est impossible de récupérer les données",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    }).then((willDelete) => {
        if (willDelete) {
            window.location = this.href;
        }
    });
});

$(document).ready(function () {
    $.validator.methods.date = function (value, element) {
        Globalize.culture("fr");
        return this.optional(element) || Globalize.parseDate(value) !== null;
    }
    $.fn.datetimepicker.Constructor.Default = $.extend({}, $.fn.datetimepicker.Constructor.Default, {
        icons: {
            time: 'far fa-clock',
            date: 'far fa-calendar',
            up: 'fas fa-chevron-up',
            down: 'fas fa-chevron-down',
            previous: 'fas fa-chevron-left',
            next: 'fas fa-chevron-right',
            today: 'far fa-calendar-check-o',
            clear: 'far fa-trash',
            close: 'far fa-times'
        }
    });

    $('#dateHourAppointment').datetimepicker({
        locale: 'fr',
        format: 'DD/MM/YYYY HH:mm',
        minDate: Date.now(),
        disabledHours: [0, 1, 2, 3, 4, 5, 6, 7, 19, 20, 21, 22, 23, 24],
        stepping : 60
    });





    $('#searchAppointment').datetimepicker({
        locale: 'fr',
        format: 'DD/MM/YYYY',
    });



    
});