// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// wwwroot/js/site.js
// Initializes Bootstrap toasts to auto-dismiss after 3 seconds
document.addEventListener('DOMContentLoaded', function () {
    // Select all toast elements
    const toastElements = document.querySelectorAll('.toast');
    toastElements.forEach(function (toastElement) {
        // Initialize toast with auto-dismiss after 3000ms
        const toast = new bootstrap.Toast(toastElement, {
            delay: 3000 // Auto-dismiss after 3 seconds
        });
        toast.show(); // Show the toast immediately
    });
});