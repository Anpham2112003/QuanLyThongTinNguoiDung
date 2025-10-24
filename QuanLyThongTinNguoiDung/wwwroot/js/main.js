function showAlert(message, type) {
    // type có thể là: success, danger, warning, info
    var alertHtml = `
        <div class="alert alert-${type} alert-dismissible fade show mt-3" role="alert">
            ${message}
            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
        </div>`;

    // Xóa alert cũ (nếu có), rồi chèn alert mới
    $('#alertPlaceholder').html(alertHtml);


    // Tự động ẩn alert sau 3 giây
    setTimeout(function () {
        $('.alert').fadeOut();
    }, 3000);
};