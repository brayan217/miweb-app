// ============================================
// INICIALIZAR AOS
// ============================================
document.addEventListener('DOMContentLoaded', function() {
    AOS.init({
        duration: 800,
        easing: 'ease-out-quad',
        once: true,
        offset: 100
    });
});

// ============================================
// PARTICULAS
// ============================================
particlesJS('particles-js', {
    particles: {
        number: { value: 80, density: { enable: true, value_area: 800 } },
        color: { value: '#00CFFF' },
        shape: { type: 'circle' },
        opacity: { value: 0.06, random: true },
        size: { value: 2, random: true },
        line_linked: {
            enable: true,
            distance: 150,
            color: '#7A00FF',
            opacity: 0.04,
            width: 1
        },
        move: {
            enable: true,
            speed: 1.5,
            direction: 'none',
            random: true,
            straight: false,
            out_mode: 'out'
        }
    },
    interactivity: {
        detect_on: 'canvas',
        events: {
            onhover: { enable: true, mode: 'grab' },
            onclick: { enable: true, mode: 'push' }
        },
        modes: {
            grab: { distance: 200, line_linked: { opacity: 0.15 } },
            push: { particles_nb: 4 }
        }
    },
    retina_detect: true
});

// ============================================
// NAVBAR SCROLL
// ============================================
const navbar = document.getElementById('mainNavbar');

window.addEventListener('scroll', function() {
    if (window.scrollY > 50) {
        navbar.classList.add('scrolled');
    } else {
        navbar.classList.remove('scrolled');
    }
});

// ============================================
// GSAP ANIMACIONES
// ============================================
gsap.registerPlugin(ScrollTrigger);

// Hero
gsap.from('.hero-title', {
    duration: 1.2,
    y: 60,
    opacity: 0,
    ease: 'power3.out'
});

gsap.from('.hero-subtitle', {
    duration: 1.2,
    y: 40,
    opacity: 0,
    delay: 0.3,
    ease: 'power3.out'
});

gsap.from('.hero-buttons', {
    duration: 1.2,
    y: 30,
    opacity: 0,
    delay: 0.6,
    ease: 'power3.out'
});

// Tarjetas de productos con ScrollTrigger
document.querySelectorAll('.product-item').forEach((card, i) => {
    gsap.from(card, {
        scrollTrigger: {
            trigger: card,
            start: 'top 85%',
            toggleActions: 'play none none none'
        },
        duration: 0.8,
        y: 40,
        opacity: 0,
        delay: i * 0.08,
        ease: 'power3.out'
    });
});

// ============================================
// EFECTO DE MOUSE EN 3D (Tarjetas)
// ============================================
document.querySelectorAll('.product-item').forEach(card => {
    card.addEventListener('mousemove', function(e) {
        const rect = this.getBoundingClientRect();
        const x = e.clientX - rect.left;
        const y = e.clientY - rect.top;
        const centerX = rect.width / 2;
        const centerY = rect.height / 2;
        const rotateX = (y - centerY) / 20;
        const rotateY = (centerX - x) / 20;

        this.style.transform =
            `perspective(800px) rotateX(${rotateX}deg) rotateY(${rotateY}deg) translateY(-8px)`;
        this.style.transition = 'transform 0.1s ease';
    });

    card.addEventListener('mouseleave', function() {
        this.style.transform = 'perspective(800px) rotateX(0deg) rotateY(0deg) translateY(0px)';
        this.style.transition = 'transform 0.6s ease';
    });
});

// ============================================
// EFECTO DE GLOW AL HACER CLICK
// ============================================
document.querySelectorAll('.btn-add, .btn-rog-hero, .btn-login-neon, .btn-rog-primary').forEach(btn => {
    btn.addEventListener('click', function(e) {
        const rect = this.getBoundingClientRect();
        const x = e.clientX - rect.left;
        const y = e.clientY - rect.top;

        const glow = document.createElement('span');
        glow.style.cssText = `
            position: absolute;
            top: ${y}px;
            left: ${x}px;
            width: 80px;
            height: 80px;
            border-radius: 50%;
            background: radial-gradient(circle, rgba(0,207,255,0.15) 0%, transparent 70%);
            transform: translate(-50%, -50%);
            pointer-events: none;
            animation: glowPulse 0.6s ease forwards;
        `;
        this.style.position = 'relative';
        this.style.overflow = 'hidden';
        this.appendChild(glow);

        setTimeout(() => glow.remove(), 600);
    });
});

// ============================================
// ANIMACIÓN DE GLOW PULSE
// ============================================
const styleGlowPulse = document.createElement('style');
styleGlowPulse.textContent = `
    @keyframes glowPulse {
        0% { transform: translate(-50%, -50%) scale(0); opacity: 1; }
        100% { transform: translate(-50%, -50%) scale(3); opacity: 0; }
    }
`;
document.head.appendChild(styleGlowPulse);

// ============================================
// EFECTO DE CARGA DE PÁGINA
// ============================================
window.addEventListener('load', function() {
    document.body.classList.add('loaded');
});