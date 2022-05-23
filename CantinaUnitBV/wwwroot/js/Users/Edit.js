$(document).ready(function () {
    $("form").submit(function (event) {
        event.preventDefault();

        //Serialize the form datas.   
        // var valdata = $("#userCreate").serialize();
        var valdata = {
            firstName: $("#firstName").val(),
            secondName: $("#secondName").val(),
            roleId: $("#roleId").val(),
        };

        var userResponseId = $("#UserResponse_Id").val();
       

        console.log(valdata);
        $.ajax({
            url: "/api/users/" + userResponseId,// `/api/users/${userResponseId}`
            type: "PUT",
            dataType: "json",
            contentType: "application/json;charset=UTF-8",
            data: JSON.stringify(valdata),
            success: function (result) {
                alert('Successfully received Data ');
                console.log(result);
                window.location.assign("/users");
            },
            error: function () {
                alert('Failed to receive the Data');
                console.log('Failed');
            },
        });


    });
});