!function () { "use strict"; var a = (e, t) => (e = e.trim(), t ? [...document.querySelectorAll(e)] : document.querySelector(e)), o = (t, e, i, o) => { let l = a(e, o); l && (o ? l.forEach(e => e.addEventListener(t, i)) : l.addEventListener(t, i)) }, e = (e, t) => { e.addEventListener("scroll", t) }; let t = a("#navbar .scrollto", !0); var i = () => { var i = window.scrollY + 200; t.forEach(e => { var t; !e.hash || (t = a(e.hash)) && (i >= t.offsetTop && i <= t.offsetTop + t.offsetHeight ? e.classList.add("active") : e.classList.remove("active")) }) }; window.addEventListener("load", i), e(document, i); var l = e => { e = a(e).offsetTop; window.scrollTo({ top: e, behavior: "smooth" }) }; let s = a(".back-to-top"); s && (c = () => { 100 < window.scrollY ? s.classList.add("active") : s.classList.remove("active") }, window.addEventListener("load", c), e(document, c)), o("click", ".mobile-nav-toggle", function (e) { a("body").classList.toggle("mobile-nav-active"), this.classList.toggle("bi-list"), this.classList.toggle("bi-x") }), o("click", ".scrollto", function (e) { if (a(this.hash)) { e.preventDefault(); let t = a("body"); if (t.classList.contains("mobile-nav-active")) { t.classList.remove("mobile-nav-active"); let e = a(".mobile-nav-toggle"); e.classList.toggle("bi-list"), e.classList.toggle("bi-x") } l(this.hash) } }, !0), window.addEventListener("load", () => { window.location.hash && a(window.location.hash) && l(window.location.hash) }); let n = a("#preloader"); n && window.addEventListener("load", () => { n.remove() }); const r = a(".typed"); if (r) { let e = r.getAttribute("data-typed-items"); e = e.split(","), new Typed(".typed", { strings: e, loop: !0, typeSpeed: 50, backSpeed: 30, backDelay: 2e3 }) } var c = a(".skills-content"); c && new Waypoint({ element: c, offset: "80%", handler: function (e) { let t = a(".progress .progress-bar", !0); t.forEach(e => { e.style.width = e.getAttribute("aria-valuenow") + "%" }) } }), window.addEventListener("load", () => { var e = a(".portfolio-container"); if (e) { let t = new Isotope(e, { itemSelector: ".portfolio-item" }), i = a("#portfolio-flters li", !0); o("click", "#portfolio-flters li", function (e) { e.preventDefault(), i.forEach(function (e) { e.classList.remove("filter-active") }), this.classList.add("filter-active"), t.arrange({ filter: this.getAttribute("data-filter") }), t.on("arrangeComplete", function () { AOS.refresh() }) }, !0) } }), GLightbox({ selector: ".portfolio-lightbox" }), GLightbox({ selector: ".portfolio-details-lightbox", width: "90%", height: "90vh" }), new Swiper(".portfolio-details-slider", { speed: 400, loop: !0, autoplay: { delay: 5e3, disableOnInteraction: !1 }, pagination: { el: ".swiper-pagination", type: "bullets", clickable: !0 } }), new Swiper(".testimonials-slider", { speed: 600, loop: !0, autoplay: { delay: 5e3, disableOnInteraction: !1 }, slidesPerView: "auto", pagination: { el: ".swiper-pagination", type: "bullets", clickable: !0 } }), window.addEventListener("load", () => { AOS.init({ duration: 1e3, easing: "ease-in-out", once: !0, mirror: !1 }) }) }();