/**
 * Donald Plugin - Product Single Page
 * 
 * @requires Slider
 * @requires ProductSingle
 * @requires PhotoSwipe
 * @instance single
 */

(function ($) {

    // Private Properties

    var $product;

    var alertCartAdded = function () {
        $(Donald.parseTemplate(ProductSinglePage.templateCartAddedAlert, {
            name: $product.find('h1.product-name').text()
        }))
            .insertBefore($product).fadeIn();
        $('.sticky-sidebar').trigger('recalc.pin');
    }

    var openFullImage = function (e) {
        e.preventDefault();

        var $this = $(e.currentTarget),
            $images,
            images;

        if ($product.find('.product-single-carousel').length) {
            // single carousel
            $images = $product.find('.product-single-carousel .owl-item:not(.cloned) img');

        } else if ($product.find('.product-gallery-carousel').length) {
            // gallery carousel
            $images = $product.find('.product-gallery-carousel .owl-item:not(.cloned) img');

        } else {
            // simple gallery
            $images = $product.find('.product-gallery img');
        }

        // if images exist
        if ($images.length) {
            var images = $images.map(function () {
                var $this = $(this);

                return {
                    src: $this.attr('data-zoom-image'),
                    w: 800,
                    h: 899,
                    title: $this.attr('alt')
                };
            }).get(),

                carousel = $product.find('.product-single-carousel, .product-gallery-carousel').data('owl.carousel'),
                currentIndex = carousel ?
                    // Carousel Type
                    ((carousel.current() - carousel.clones().length / 2 + images.length) % images.length) :

                    // Gallery Type
                    ($product.find('.product-gallery > *').index());

            if (typeof PhotoSwipe !== 'undefined') {
                var pswpElement = $('.pswp')[0];

                var photoswipe = new PhotoSwipe(pswpElement, PhotoSwipeUI_Default, images, {
                    index: currentIndex,
                    // mouseUsed: true,
                    closeOnScroll: false,
                });
                photoswipe.init();
                Donald.photoswipe = photoswipe;
            }
        }
    }

    // Rating Form(new)
    var ratingForm = function () {
        $('body').on('click', '.rating-form .rating-stars > a', function (e) {
            var $star = $(this);
            $star.addClass('active').siblings().removeClass('active');
            $star.parent().addClass('selected');
            $star.closest('.rating-form').find('select').val($star.text());
            e.preventDefault();
        });
    }

    // Public Properties

    var ProductSinglePage = {
        templateCartAddedAlert: '<div class="alert alert-simple alert-btn cart-added-alert">' +
            '<a href="cart.html" class="btn btn-success btn-md">View Cart</a>' +
            '<span>"{{name}}" has been added to your cart.</span>' +
            '<button type="button" class="btn btn-link btn-close"><i class="d-icon-times"></i></button>' +
            '</div>',

        init: function () {

            $product = $('.product-single');

            if ($product.length) {
                // if home page, init single products
                if (document.body.classList.contains('home')) {
                    $product.each(function () {
                        Donald.productSingle($(this));
                    });

                    return null;

                    // else, init single product page
                } else {
                    if (Donald.productSingle($product) === null) {
                        return null;
                    }
                }
            } else {
                // if no single product exists, return
                return null;
            }

            // add gallery slider type
            Slider.presets['product-gallery-carousel'] = {
                dots: false,
                nav: true,
                margin: 20,
                items: 1,
                responsive: {
                    576: {
                        items: 2
                    },
                    768: {
                        items: 3
                    }
                },
                onInitialized: Slider.zoomImage,
                onRefreshed: Slider.zoomImageRefresh
            };

            // image zoom for grid type

            //Donald.zoomImage('.product-gallery:not(.product-gallery-carousel)');
            Donald.zoomImage('.product-gallery.row');

            // image full
            $product.on('click', '.product-image-full', openFullImage);

            // cart added alert

            $product.on('click', '.btn-cart:not(.disabled)', alertCartAdded);

            // init rating from.(new)
            ratingForm();
        }
    }

    Donald.productSinglePage = ProductSinglePage;

})(jQuery);
