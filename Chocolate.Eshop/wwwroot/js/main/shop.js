/**
 * Donald Plugin - Shop
 * 
 * @requires Minipopup
 * @requires noUiSlider
 * @instance single
 */

(function ($) {

    // Private Properties

    var initSelectMenu = function () {

        var selector = '.select-menu';

        // show or hide select menu
        Donald.$body.on('mousedown', '.select-menu', function (e) {
            var $selectMenu = $(e.currentTarget),
                $target = $(e.target),
                isOpened = $selectMenu.hasClass('opened');

            // close all select menu
            $('.select-menu').removeClass('opened');

            if ($selectMenu.is($target.parent())) {
                // if toggle is clicked
                !isOpened && $selectMenu.addClass('opened');

                e.stopPropagation();
            } else {
                // if item is clicked
                $target.parent().toggleClass('active');

                if ($target.parent().hasClass('active')) {

                    // if only clean all button remains
                    if ($('.select-items').children().length < 2) {
                        // then hide select-items
                        $('.select-items').show();
                    }

                    // add select item
                    $('<a href="#" class="select-item">' + $target.text() + '<i class="la la-close"></i></a>')
                        .insertBefore('.select-items .filter-clean')
                        .hide().fadeIn()
                        .data('link', $target.parent()); // link to anchor's parent - li tag
                } else {
                    // remove select item
                    $('.select-items > .select-item').filter(function (i, el) {
                        return el.innerText == $target.text();
                    }).fadeOut(function () {
                        $(this).remove();

                        // if only clean all button remains
                        if ($('.select-items').children().length < 2) {
                            // then hide select-items
                            $('.select-items').hide();
                        }
                    });
                }
            }
        });

        // Filter clean

        $('.select-items .filter-clean').on('click', function (e) {
            $(this).siblings().each(function () {
                var $link = $(this).data('link');
                $link && $link.removeClass('active');
            });
            $(this).parent().fadeOut();
            e.preventDefault();
        });

        $('.filter-clean').on('click', function (e) {
            $('.shop-sidebar .filter-items .active').removeClass('active');
            e.preventDefault();
        });

        Donald.$body.on('click', '.select-menu a', function (e) {
            e.preventDefault();
        });

        Donald.$body.on('click', '.select-item i', function (e) {
            $(e.currentTarget).parent().fadeOut(function () {
                var $this = $(this),
                    $link = $this.data('link');
                $link && $link.toggleClass('active');
                $this.remove();

                // if only clean all button remains
                if ($('.select-items').children().length < 2) {
                    // then hide select-items
                    $('.select-items').hide();
                }
            });
            e.preventDefault();
        });

        // if click is happend outside of select menu, hide it
        Donald.$body.on('mousedown', function (e) {
            $('.select-menu').removeClass('opened');
        });

        // active filter item
        Donald.$body.on('click', '.filter-items a', function (e) {
            var $ul = $(this).closest('.filter-items');
            if (!$ul.hasClass('search-ul') && !$ul.parent().hasClass('select-menu')) {
                $(this).parent().toggleClass('active');
                e.preventDefault();
            }
        })
    }


    var initProductsQuickview = function () {
        Donald.$body.on('click', '.btn-quickview', function (e) {
            e.preventDefault();
            Donald.popup({
                items: {
                    src: "ajax/quickview.html"
                },
                callbacks: {
                    ajaxContentAdded: function () {
                        this.wrap.imagesLoaded(function () {
                            Donald.productSingle($('.mfp-product .product-single'));
                        });
                    }
                }
            }, 'quickview');
        });
    }

    var initProductsCartAction = function () {
        // Add to cart in products
        Donald.$body.on('click', '.btn-product-icon.btn-cart, .btn-product.btn-cart', function (e) {
            e.preventDefault();

            var $product = $(this).closest('.product');

            // if not product single, then open minipopup
            if (!$product.hasClass('product-single')) {
                var oldCartPrice = parseFloat($('.cart-price').text().trim().slice(1));
                var oldCartCount = parseFloat($('.cart-count').text());
                var productPrice = parseFloat($product.find('.product-price').text().trim().slice(1));

                // Add to Cart actions
                // $('.cart-price').text('$' + (oldCartPrice + productPrice).toFixed(2));
                // $('.cart-count').text(oldCartCount + 1);

                // var product = {};
                // product.name = $product.find('.product-name').text().trim();
                // var price_text;
                // if( 0 == $product.find('.new-price').length )
                //     price_text = $product.find('.product-price > .price').text().trim().slice(1);
                // else
                //     price_text = $product.find('.product-price > .new-price').text().trim().slice(1);
                // product.price = parseFloat( price_text );
                // product.count = $product.find('.quantity').val() ? $product.find('.quantity').val() : 1;
                // addCartProducts( product );

                Donald.minipopup.open({
                    message: 'Successfully added.<a href="cart.html" class="btn btn-link btn-sm btn-slide-right btn-infinite">View Cart<i class="la la-long-arrow-right"></i></a>',
                    productClass: ' product-cart',
                    name: $product.find('.product-name').text(),
                    nameLink: $product.find('.product-name > a').attr('href'),
                    imageSrc: $product.find('.product-media img').attr('src'),
                    imageLink: $product.find('.product-name > a').attr('href'),
                    price: $product.find('.product-price').html(),
                    count: $product.find('.quantity').val()
                });
            }
        });
    }

    var initProductsLoad = function () {

        $('.btn-load').on('click', function (e) {
            var $this = $(this),
                $wrapper = $($this.data('load-to')),
                loadText = $this.html();

            $this.text('Loading ...');
            e.preventDefault();

            $.ajax({
                url: $this.attr('href'),
                success: function (result) {
                    var $newItems = $(result);

                    setTimeout(function () {
                        $wrapper.isotope('insert', $newItems);
                        $this.html(loadText);

                        var loadCount = parseInt($this.data('load-count') ? $this.data('load-count') : 0);
                        $this.data('load-count', ++loadCount);

                        // do not load more than 2 times
                        loadCount >= 2 && $this.hide();
                    }, 350);
                },
                failure: function () {
                    $this.text("Sorry something went wrong.");
                }
            });
        });
    }

    // Infinite Scroll Load
    var initProductsScrollLoad = function ($obj) {
        var $wrapper = Donald.$($obj)
            , top;
        var loadProducts = function (e) {
            if (window.pageYOffset > top + $wrapper.outerHeight() - window.innerHeight - 150 && 'loading' != $wrapper.data('load-state')) {
                $.ajax({
                    url: 'ajax/ajax-products.html',
                    success: function (result) {
                        var $newItems = $(result);
                        $wrapper.data('load-state', 'loading');
                        if (!$wrapper.next().hasClass('load-more-overlay')) {
                            $('<div class="mt-4 mb-4 load-more-overlay loading"></div>').insertAfter($wrapper);
                        } else {
                            $wrapper.next().addClass('loading');
                        }
                        setTimeout(function () {
                            $wrapper.next().removeClass('loading');
                            $wrapper.append($newItems);
                            setTimeout(function () {
                                $wrapper.find('.product-wrap.fade:not(.in)').addClass('in');
                            }, 200);
                            $wrapper.data('load-state', 'loaded');
                        }, 500);
                        var loadCount = parseInt($wrapper.data('load-count') ? $wrapper.data('load-count') : 0);
                        $wrapper.data('load-count', ++loadCount);
                        loadCount > 2 && window.removeEventListener('scroll', loadProducts, { passive: true });
                    },
                    failure: function () {
                        $this.text("Sorry something went wrong.");
                    }
                });
            }
        }
        if ($wrapper.length > 0) {
            top = $wrapper.offset().top;
            window.addEventListener('scroll', loadProducts, { passive: true });
        }
    }

    // Public Properties

    var Shop = {
        init: function () {
            // Functions for products
            initProductsQuickview();
            initProductsCartAction();
            initProductsLoad();
            initProductsScrollLoad('.scroll-load');
            Donald.call(Donald.ratingTooltip, 500);
            this.initProductType('slideup');
            this.initVariation();

            // Functions for shop page
            initSelectMenu();
            Donald.priceSlider('.filter-price-slider');
        },

        initVariation: function (type) {
            $('.product:not(.product-single) .product-variations > a').on('click', function (e) {
                var $this = $(this),
                    $image = $this.closest('.product').find('.product-media img');

                if (!$image.data('image-src'))
                    $image.data('image-src', $image.attr('src'));

                $this.toggleClass('active').siblings().removeClass('active');
                if ($this.hasClass('active')) {
                    $image.attr('src', $this.data('src'))
                } else {
                    $image.attr('src', $image.data('image-src'));
                    $this.blur();
                }
                e.preventDefault();
            })
        },

        initProductType: function (type) {

            // "slideup" type
            if (type === 'slideup') {
                $('.product-slideup-content .product-details').each(function (e) {
                    var $this = $(this),
                        hidden_height = $this.find('.product-hide-details').outerHeight(true);

                    $this.height($this.height() - hidden_height);
                });

                $(Donald.byClass('product-slideup-content'))
                    .on('mouseenter touchstart', function (e) {
                        var $this = $(this),
                            hidden_height = $this.find('.product-hide-details').outerHeight(true);

                        $this.find('.product-details').css('transform', 'translateY(' + (-hidden_height) + 'px)');
                        $this.find('.product-hide-details').css('transform', 'translateY(' + (-hidden_height) + 'px)');
                    })
                    .on('mouseleave touchleave', function (e) {
                        var $this = $(this),
                            hidden_height = $this.find('.product-hide-details').outerHeight(true);

                        $this.find('.product-details').css('transform', 'translateY(0)');
                        $this.find('.product-hide-details').css('transform', 'translateY(0)');
                    });
            }
        },

        cartProducts: {
            productList: [
                {
                    name: 'Coast Pool Comfort Jacket',
                    image: 'images/cart/product-1.jpg',
                    price: 21.00,
                    qty: 1
                },
                {
                    name: 'Fashionable Blue Leather Shoes',
                    image: 'images/cart/product-2.jpg',
                    price: 21.00,
                    qty: 1
                },
            ],
            total: 42.00
        },


    }

    Donald.shop = Shop;
})(jQuery);