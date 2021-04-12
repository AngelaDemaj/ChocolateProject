/**
 * Donald Plugin - Product Single
 * 
 * @requires OwlCarousel
 * @requires ImagesLoaded (only quickview needs)
 * @requires elevateZoom
 * @instance multiple
 */

function ProductSingle($el) {
    return this.init($el);
}

(function ($) {

    // Private Properties
    var thumbsSliderOptions = {
        margin: 0,
        items: 4,
        dots: false,
        nav: true,
        navText: ['<i class="fas fa-chevron-left">', '<i class="fas fa-chevron-right">']
    }

    var thumbsInit = function (self) {
        // members for thumbnails
        self.$thumbs = self.$wrapper.find('.product-thumbs');
        self.$thumbsWrap = self.$thumbs.parent();
        self.$thumbUp = self.$thumbsWrap.find('.thumb-up');
        self.$thumbDown = self.$thumbsWrap.find('.thumb-down');
        self.$thumbsDots = self.$thumbs.children();
        self.thumbsCount = self.$thumbsDots.length;
        self.$productThumb = self.$thumbsDots.eq(0);
        self._isPgvertical = self.$thumbsWrap.parent().hasClass('pg-vertical');
        self.thumbsIsVertical = self._isPgvertical && window.innerWidth >= Donald.desktop_width;

        // register events
        self.$thumbDown.on('click', function (e) {
            self.thumbsIsVertical && thumbsDown(self);
        });

        self.$thumbUp.on('click', function (e) {
            self.thumbsIsVertical && thumbsUp(self);
        });

        self.$thumbsDots.on('click', function () {
            var $this = $(this),
                index = ($this.parent().filter(self.$thumbs).length ? $this : $this.parent()).index();
            self.$wrapper.find('.product-single-carousel').trigger('to.owl.carousel', index);
        });

        // refresh thumbs
        thumbsRefresh(self);
        Donald.$window.on('resize', function () {
            thumbsRefresh(self);
        });
    }

    var thumbsDown = function (self) {
        var maxBottom = self.$thumbsWrap.offset().top + self.$thumbsWrap[0].offsetHeight,
            curBottom = self.$thumbs.offset().top + self.thumbsHeight;

        if (curBottom >= maxBottom + self.$productThumb[0].offsetHeight) {
            self.$thumbs.css('top', parseInt(self.$thumbs.css('top')) - self.$productThumb[0].offsetHeight);
            self.$thumbUp.removeClass('disabled');
        } else if (curBottom > maxBottom) {
            self.$thumbs.css('top', parseInt(self.$thumbs.css('top')) - Math.ceil(curBottom - maxBottom));
            self.$thumbUp.removeClass('disabled');
            self.$thumbDown.addClass('disabled');
        } else {
            self.$thumbDown.addClass('disabled');
        }
    }
    var thumbsUp = function (self) {
        var maxTop = self.$thumbsWrap.offset().top,
            curTop = self.$thumbs.offset().top;

        if (curTop <= maxTop - self.$productThumb[0].offsetHeight) {
            self.$thumbs.css('top', parseInt(self.$thumbs.css('top')) + self.$productThumb[0].offsetHeight);
            self.$thumbDown.removeClass('disabled');
        } else if (curTop < maxTop) {
            self.$thumbs.css('top', parseInt(self.$thumbs.css('top')) - Math.ceil(curTop - maxTop));
            self.$thumbDown.removeClass('disabled');
            self.$thumbUp.addClass('disabled');
        } else {
            self.$thumbUp.addClass('disabled');
        }
    }

    var thumbsRefresh = function (self) {
        if (typeof self.$thumbs == 'undefined') {
            return;
        }

        var oldIsVertical = 'undefined' == typeof self.thumbsIsVertical ? false : self.thumbsIsVertical; // is vertical?
        self.thumbsIsVertical = self._isPgvertical && window.innerWidth >= Donald.desktop_width;

        if (self.thumbsIsVertical) { // enable vertical product gallery thumbs.
            // disable thumbs carousel
            self.$thumbs.hasClass('owl-carousel') &&
                self.$thumbs
                    .trigger('destroy.owl.carousel')
                    .removeClass('owl-carousel');

            // enable thumbs vertical nav
            self.thumbsHeight = self.$productThumb[0].offsetHeight * self.thumbsCount + parseInt(self.$productThumb.css('margin-bottom')) * (self.thumbsCount - 1);
            self.$thumbUp.addClass('disabled');
            self.$thumbDown.toggleClass('disabled', self.thumbsHeight <= self.$thumbsWrap[0].offsetHeight);
            self.isQuickview && recalcDetailsHeight();
        } else {
            // if not vertical, remove top property
            oldIsVertical && self.$thumbs.css('top', '');

            // enable thumbs carousel
            self.$thumbs.hasClass('owl-carousel') || self.$thumbs.addClass('owl-carousel').owlCarousel(
                $.extend(
                    true,
                    self.isQuickview ? {
                        onInitialized: recalcDetailsHeight,
                        onResized: recalcDetailsHeight
                    } : {},
                    thumbsSliderOptions
                ));
        }
    }

    var initVariation = function (self) {
        self.$selects = self.$wrapper.find('.product-variations select');
        self.$items = self.$wrapper.find('.product-variations');
        self.$priceWrap = self.$wrapper.find('.product-variation-price');
        self.$clean = self.$wrapper.find('.product-variation-clean'),
            self.$btnCart = self.$wrapper.find('.btn-cart');

        // check
        self.variationCheck();
        self.$selects.on('change', function (e) {
            self.variationCheck();
        });
        self.$items.children('a').on('click', function (e) {
            $(this).toggleClass('active').siblings().removeClass('active');
            e.preventDefault();
            self.variationCheck();
        });

        // clean
        self.$clean.on('click', function (e) {
            e.preventDefault();
            self.variationClean(true);
        });
    }

    var initCartAction = function (self) {

        // Product Single's Add To Cart Button
        self.$wrapper.on('click', '.btn-cart', function (e) {
            e.preventDefault();

            var $product = self.$wrapper,
                name = $product.find('.product-name').text();

            // minipopup if only quickview or home pages
            if (
                $product.closest('.product-popup').length ||
                document.body.classList.contains('home')
            ) {
                Donald.minipopup.open({
                    message: 'Successfully added.<a href="cart.html" class="btn btn-link btn-sm btn-slide-right btn-infinite">View Cart<i class="la la-long-arrow-right"></i></a>',
                    productClass: ' product-cart',
                    name: name,
                    nameLink: $product.find('.product-name > a').attr('href'),
                    imageSrc: $product.find('.product-image img').eq(0).attr('src'),
                    imageLink: $product.find('.product-name > a').attr('href'),
                    price: $product.find('.product-variation-price').children('span').html(),
                    count: $product.find('.quantity').val(),
                });
            }
        });
    }

    // For only Quickview
    var recalcDetailsHeight = function () {
        var self = this;
        self.$wrapper.find('.product-details').css(
            'height',
            window.innerWidth > 767 ? self.$wrapper.find('.product-gallery')[0].clientHeight : ''
        );
    }

    // Public Properties

    ProductSingle.prototype.init = function ($el) {
        var self = this,
            $slider = $el.find('.product-single-carousel');

        // members
        self.$wrapper = $el;
        self.isQuickview = !!$el.closest('.mfp-content').length;
        self._isPgvertical = false;

        // bind
        if (self.isQuickview) {
            recalcDetailsHeight = recalcDetailsHeight.bind(this);
            Donald.ratingTooltip();
        }

        // init thumbs
        $slider.on('initialized.owl.carousel', function (e) {

            // if not quickview, make full image toggle
            self.isQuickview || $slider.append('<a href="#" class="product-image-full"><i class="d-icon-zoom"></i></a>');

            // init thumbnails
            thumbsInit(self);

        }).on('translate.owl.carousel', function (e) {
            var currentIndex = (e.item.index - $(e.currentTarget).find('.cloned').length / 2 + e.item.count) % e.item.count;
            self.thumbsSetActive(currentIndex);
        });

        // if this is created after document ready, init plugins
        if ('complete' === Donald.status) {
            Donald.slider($slider);
            Donald.quantityInput($el.find('.quantity'));
        }

        initVariation(this);
        initCartAction(this);
    }

    ProductSingle.prototype.thumbsSetActive = function (index) {
        var self = this,
            $curThumb = self.$thumbsDots.eq(index);

        self.$thumbsDots.filter('.active').removeClass('active');
        $curThumb.addClass('active');

        // show current thumb
        if (self.thumbsIsVertical) { // if vertical
            var offset = parseInt(self.$thumbs.css('top')) + index * self.thumbsHeight;

            if (offset < 0) {
                // if above
                self.$thumbs.css('top', parseInt(self.$thumbs.css('top')) - offset);
            } else {
                offset = self.$thumbs.offset().top + self.$thumbs[0].offsetHeight - $curThumb.offset().top - $curThumb[0].offsetHeight;

                if (offset < 0) {
                    // if below
                    self.$thumbs.css('top', parseInt(self.$thumbs.css('top')) + offset);
                }
            }
        } else { // if thumb carousel
            self.$thumbs.trigger('to.owl.carousel', index, 100);
        }
    }

    ProductSingle.prototype.variationCheck = function () {
        var self = this,
            isAllSelected = true;

        // check all select variations are selected
        self.$selects.each(function () {
            return this.value || (isAllSelected = false);
        });

        // check all item variations are selected
        self.$items.each(function () {
            var $this = $(this);
            if ($this.children('a:not(.size-guide)').length) {
                return $this.children('.active').length || (isAllSelected = false);
            }
        });

        isAllSelected ?
            self.variationMatch() :
            self.variationClean();
    }

    ProductSingle.prototype.variationMatch = function () {
        var self = this;
        self.$priceWrap.find('span').text('$' + (Math.round(Math.random() * 50) + 200) + '.00');
        self.$priceWrap.slideDown();
        self.$clean.slideDown();
        // self.$clean.css('display', 'inline-block');
        self.$btnCart.removeAttr('disabled');
    }

    ProductSingle.prototype.variationClean = function (reset) {
        reset && this.$selects.val('');
        reset && this.$items.children('.active').removeClass('active');
        this.$priceWrap.slideUp();
        this.$clean.css('display', 'none');
        this.$btnCart.attr('disabled', 'disabled');

    }

    Donald.productSingle = function ($el, options) {
        if ($el && $el.length === 1) {
            return new ProductSingle($el.eq(0), options);
        }
        return null;
    }
})(jQuery);

