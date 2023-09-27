async function sendMessage() {
    $('.loading').show();
    await $.ajax({
        url: '/Index?Handler=sendMessage',
        type: 'POST',
        data: $('#form-message').serialize(),
        success: function (res) {
            if (res != undefined && res != null && res != "خطا") {
                $('.loading').hide();
                $('.sent-message').show();
            }
            else {
                $('.loading').hide();
                $('.error-message').show();
            }
        }
    });
}