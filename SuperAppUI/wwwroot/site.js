let lastScrollTop = 0;

window.addEventListener("scroll", function () {
    const navbar = document.querySelector(".top-row");
    if (!navbar) return;

    let currentScroll = window.scrollY || document.documentElement.scrollTop;

    if (currentScroll > lastScrollTop && currentScroll > 50) {
        // User scrolled down → hide the navbar
        navbar.classList.add("hidden");
    } else {
        // User scrolled up → show the navbar
        navbar.classList.remove("hidden");
    }

    lastScrollTop = currentScroll <= 0 ? 0 : currentScroll;
}, false);
