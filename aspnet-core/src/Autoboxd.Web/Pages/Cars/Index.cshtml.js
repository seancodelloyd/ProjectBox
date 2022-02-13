$(function () {
    var myWidgetManager = new abp.WidgetManager({
        wrapper: '.cars',
        filterCallback: function () {
            return {
                'entityId': $("#itemId").text()
            };
        }
    });
    myWidgetManager.init();

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

        debugger;
        var itemId = $("#itemId").text();
        var commentValue = tinymce.get("commentBox").getContent();

        autoboxd.comments.comment
            .create({
                EntityId: itemId,
                Value: commentValue
            }).then(function (result) {
                toastr.success("Comment added");
                myWidgetManager.refresh();
            });
    });

    var createAndAddModal = new abp.ModalManager(abp.appPath + 'Lists/CreateAndAddModal' + '?itemId=' + itemId.innerText);

    $("#createNewList").on("click", function (e) {
        e.preventDefault();
        createAndAddModal.open();
    });
});