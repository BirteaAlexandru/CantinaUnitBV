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
            {
                data: "firstName",
                render: function (data, type, row) {
                    return `<a href="/users/details?id=${row.id}">${data}</a>`;
                }
            },
            {
                data: "secondName",
                render: function (data, type, row) {
                    return `<a href="/users/details?id=${row.id}">${data}</a>`;
                }
            },
            { data: "email" },
            { data: "roleName" },
            {
                data: "",
                orderable: false,
                render: function (data, type, row) {
                    return `<a href="/users/Edit?id=${row.id}">Edit</a> | <a href="users/delete?id=${row.id}">Delete</a>`
                }
            }
        ],
        order: [0, "asc"]
    });
})
