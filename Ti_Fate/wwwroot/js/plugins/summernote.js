$("#summernote").summernote({
    dialogsInBody: true,
    maximumImageFileSize: 1024 * 1024 * 3,
    callbacks: {
        onImageUploadError: function (msg) {
            alert(msg + " (2 MB)");
        }
    },
    placeholder: "請輸入公告內容...",
    height: 500,
    toolbar: [
        ["style", ["bold", "italic", "underline", "clear"]],
        ["font", ["strikethrough", "superscript", "subscript"]],
        ["fontsize", ["fontsize"]],
        ["fontname", ["fontname"]],
        ["color", ["color"]],
        ["para", ["ul", "ol", "paragraph"]],
        ["table", ["table"]],
        ["insert", ["link", "picture"]]
    ]
});

var body = '<div class="form-group note-form-group">' +
    '<div class="help-block note-help-block">Helpful text block</div>' +
    '</div>' +
    '<div class="form-group note-form-group">' +
    '<label for="note-input-1" class="control-label note-form-label">Input Label 1</label>' +
    '<div class="input-group note-input-group">' +
    '<input type="text" id="note-input-1" class="form-contro note-input">' +
    '</div>' +
    '</div>';


$('.note-image-dialog, .note-link-dialog, .note-video-dialog, .note-help-dialog').on('show.bs.modal', function () {
    $(this).detach().appendTo('body');
});

$('.note-image-dialog, .note-link-dialog, .note-video-dialog, .note-help-dialog').on('hide.bs.modal', function () {
    $(this).detach().appendTo('.note-dialog');
});