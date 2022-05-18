$(document).ready(function() {
    const table = $("#usersTable").DataTable({
        stateSave: false,
        autoWidth: true,
        // ServerSide Setups
        processing: true,
        serverSide: true,
        // Paging Setups
        paging: true,
        // Searching Setups
        searching: { regex: true },
        dom: "lfrtip",
        ajax: {
            url: "api/users/search",
            type: "POST",
            dataType: "json",
            contentType: "application/json;charset=UTF-8",
            data: function(data) {
                return JSON.stringify(data);
            }
        },
        columns: [
            { data: "id" },
            { data: "firstName" },
            { data: "secondName" },
            { data: "email" },
            { data: "roleName" }
        ],
        order: [0, "asc"]
    });
})
