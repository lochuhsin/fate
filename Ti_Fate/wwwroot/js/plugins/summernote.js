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