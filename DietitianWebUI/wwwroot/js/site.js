function showInPopup(url, title) {
    $.ajax({
        type: "GET",
        url: url,
        success: function (res) {
            $("#centermodal .modal-body").html(res);
            $("#centermodal .modal-title").html(title);

            $("#centermodal").modal('show');
        }
    })
};
