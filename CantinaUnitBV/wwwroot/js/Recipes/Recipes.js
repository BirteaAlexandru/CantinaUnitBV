$(document).ready(function () {
    const table = $("#recipesTable").DataTable({
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
            url: "api/recipes/search",
            type: "POST",
            dataType: "json",
            contentType: "application/json;charset=UTF-8",
            data: function (data) {
                return JSON.stringify(data);
            }
        },
        columns: [
            { data: "id" },
            { data: "name" },
            { data: "price" },
            { data: "ingredients" },
            { data: "available" },
            { data: "quantity" }

        ],
        order: [0, "asc"]
    });
})
