$(document).ready(function () {
    $("form").submit(function (event) {
        var UserId = $("#User_Id").val();
        $.ajax({
            url: "/api/Users/" + UserId,
            type: 'Delete',
            dataType: "json",
            contentType: "application/json;charset=UTF-8",

            success: function (result) {
                alert('Successfully deleted Data ');
                console.log(result);
                window.location.assign("/users");
            },
            error: function () {
                alert('Failed to delete the Data');
                console.log('Failed');
            },
        });
        event.preventDefault();
    });

});