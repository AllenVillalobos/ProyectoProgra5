document.addEventListener('DOMContentLoaded', () => {
    // Hero (si tienes sección .hero)
    const hero = document.querySelector('.hero');
    if (hero) setTimeout(() => hero.classList.add('visible'), 100);

    // Navbar cambia al hacer scroll
    const nav = document.querySelector('header.navbar');
    if (nav) {
        window.addEventListener('scroll', () => {
            nav.classList.toggle('scrolled', window.scrollY > 50);
        });
    }

    // Observador para fade-in
    const obs = new IntersectionObserver((entries) => {
        entries.forEach(e => {
            if (e.isIntersecting) {
                e.target.classList.add('visible');
                obs.unobserve(e.target);
            }
        });
    }, { threshold: 0.2 });

    document.querySelectorAll('.fade-in').forEach(el => obs.observe(el));
});
