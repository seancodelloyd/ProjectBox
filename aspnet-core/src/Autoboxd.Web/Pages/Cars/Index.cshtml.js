$(function () {
    var addToListButton = $(".addToList");

    addToListButton.on("click", function (event) {
        event.preventDefault();

        var listId = event.currentTarget.id;
        var itemId = $("#itemId").text();

        autoboxd.lists.list
            .addItem(listId, itemId)
            .then(function (result) {
                toastr.success("Successfully added to the list")
            });;
    });

    var postCommentButton = $("#postComment");

    postCommentButton.on("click", function (event) {
        event.preventDefault();

        var itemId = $("#itemId").text();

        //autoboxd.lists.list
        //    .addItem(listId, itemId)
        //    .then(function (result) {
        //        toastr.success("Successfully added to the list")
        //    });;
    });
});