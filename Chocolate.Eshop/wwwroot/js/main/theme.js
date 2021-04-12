/**
 * Donald Theme
 */
(function ($) {

    // Initialize Method while document is being loaded.
    Donald.prepare = function () {
        Donald.$body.hasClass('with-flex-container') && window.innerWidth >= 1200 &&
            Donald.$body.addClass('sidebar-active');
    };

    // Initialize Method while document is interactive
    Donald.initLayout = function () {
        Donald.isotopes('.grid:not(.grid-float)');
        Donald.stickySidebar('.sticky-sidebar');
    }

    // Initialize Method after document has been loaded
    Donald.init = function () {
        Donald.appearAnimate('.appear-animate');            // Runs appear animations
        Donald.minipopup.init();                            // Initialize minipopup
        Donald.shop.init();                                 // Initialize shop
        Donald.productSinglePage.init();                    // Initialize single product page
        Donald.slider('.owl-carousel');                     // Initialize slider
        Donald.headerToggleSearch('.hs-toggle');            // Initialize header toggle search
        Donald.stickyContent('.product-sticky-content, .sticky-header');            // Initialize sticky content
        Donald.stickyContent('.sticky-footer', {
            minWidth: 0,
            maxWidth: 767,
            top: 150,
            hide: true,
            max_index: 2100
        });
        Donald.sidebar('sidebar');                          // Initialize left sidebar
        Donald.sidebar('right-sidebar');                    // Initialize right sidebar
        Donald.quantityInput('.quantity');                  // Initialize quantity input
        Donald.playableVideo('.post-video');                // Initialize playable video
        Donald.accordion('.card-header > a');               // Initialize accordion
        Donald.tab('.nav-tabs');                            // Initialize tab
        Donald.alert('.alert');                             // Initialize alert
        Donald.parallax('.parallax');                       // Initialize parallax
        Donald.countTo('.count-to');                        // Initialize countTo
        Donald.countdown('.product-countdown, .countdown'); // Initialize countdown
        Donald.menu.init();                                 // Initialize menus
        Donald.initNavFilter('.nav-filters .nav-filter');   // Initialize navigation filters for blog, products
        Donald.initPopups();                                // Initialize popups: login, register, play video, newsletter popup
        Donald.initPurchasedMinipopup();                    // Initialize minipopup for purchased event
        Donald.initScrollTopButton();                       // Initialize scroll top button.

        // if Docs plugins is included, init it
        Donald.docs && Donald.docs.init();

        // Setup Events
        Donald.$window.on('resize', Donald.onResize);
    }

    Donald.onResize = function () {
        // refresh zoom images.
        Donald.zoomImageOnResize();
    }
})(jQuery);

/**
 * Donald Theme Initializer
 */
(function ($) {
    'use strict';

    // Prepare Donald Theme
    Donald.prepare();

    // Initialize Donald Theme
    document.onreadystatechange = function () {
        if (document.readyState === "complete") {
        }
    }
    window.onload = function () {
        // loaded
        Donald.status = 'loaded';
        document.body.classList.add('loaded');
        Donald.status = 'complete';

        Donald.call(Donald.initLayout);
        Donald.call(Donald.init);
    }
})(jQuery);

