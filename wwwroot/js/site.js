// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener("DOMContentLoaded", function () {

    const elements = document.querySelectorAll(".reveal");

    const observer = new IntersectionObserver(entries => {

        entries.forEach(entry => {

            if (entry.isIntersecting) {

                // reset để animation chạy lại
                entry.target.classList.remove("active");

                void entry.target.offsetWidth; // trick restart animation

                entry.target.classList.add("active");

            }

        });

    }, {
        threshold: 0.5
    });

    elements.forEach(el => observer.observe(el));
});