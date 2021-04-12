/**
 * Donald Dependent Plugin - Slider
 * 
 * @requires OwlCarousel
 * @instance multiple
 */

function Slider($el, options) {
    return this.init($el, options);
}

(function ($) {

    // Private Properties

    var onInitialize = function (e) {
        var i, j, breaks = ['', '-xs', '-sm', '-md', '-lg', '-xl'];
        this.classList.remove('row');
        for (i = 0; i < 6; ++i) {
            for (j = 1; j <= 12; ++j) {
                this.classList.remove('cols' + breaks[i] + '-' + j);
            }
        }
        this.classList.remove('gutter-no');
        this.classList.remove('gutter-sm');
        this.classList.remove('gutter-lg');
        if (this.classList.contains("animation-slider")) {
            var els = this.children,
                len = els.length;
            for (var i = 0; i < len; ++i) {
                els[i].setAttribute('data-index', i + 1);
            }
        }
    }
    var onInitialized = function (e) {
        var els = this.firstElementChild.firstElementChild.children,
            i,
            len = els.length;
        for (i = 0; i < len; ++i) {
            if (!els[i].classList.contains('active')) {
                var animates = Donald.byClass('appear-animate', els[i]),
                    j;
                for (j = animates.length - 1; j >= 0; --j) {
                    animates[j].classList.remove('appear-animate');
                }
            }
        }
    }
    var onSliderInitialized = function (e) {
        var self = this,
            $el = $(e.currentTarget);

        // $this.find('.owl-item').eq(e.item.index - e.item.count).find('.slide-animate').addClass('show-content');
        // $this.find('.owl-item').eq(e.item.index + e.item.count).find('.slide-animate').addClass('show-content');

        // carousel content animation
        $el.find('.owl-item.active .slide-animate').each(function () {
            var $animation_item = $(this),
                settings = $.extend(true, {},
                    Donald.animationOptions,
                    Donald.parseOptions($animation_item.data('animation-options'))
                ),
                duration = settings.duration,
                delay = settings.delay,
                aniName = settings.name;

            setTimeout(function () {
                $animation_item.css('animation-duration', duration);
                $animation_item.css('animation-delay', delay);
                $animation_item.addClass(aniName);

                if ($animation_item.hasClass('maskLeft')) {
                    $animation_item.css('width', 'fit-content');
                    var width = $animation_item.width();
                    $animation_item.css('width', 0).css(
                        'transition',
                        'width ' + (duration ? duration : '0.75s') + ' linear ' + (delay ? delay : '0s'));
                    $animation_item.css('width', width);
                }
                duration = duration ? duration : '0.75s';
                var temp = Donald.requestTimeout(function () {
                    $animation_item.addClass('show-content');
                }, (delay ? Number((delay).slice(0, -1)) * 1000 + 200 : 200));

                self.timers.push(temp);
            }, 300);
        });
    }
    var onSliderResized = function (e) {
        $(e.currentTarget).find('.owl-item.active .slide-animate').each(function () {
            var $animation_item = $(this);
            $animation_item.addClass('show-content');
            $animation_item.attr('style', '');
        });
    }

    var onSliderTranslate = function (e) {
        var self = this,
            $el = $(e.currentTarget);
        self.translateFlag = 1;
        self.prev = self.next;
        $el.find('.owl-item .slide-animate').each(function () {
            var $animation_item = $(this),
                settings = $.extend(true, {}, Donald.animationOptions, Donald.parseOptions($animation_item.data('animation-options')));
            $animation_item.removeClass(settings.name);
            // $animation_item.removeClass($animation_item.data('show-content'));
            // $animation_item.css('animation-play-state','paused');
        });
    }

    var onSliderTranslated = function (e) {
        var self = this,
            $el = $(e.currentTarget);
        if (1 == self.translateFlag) {
            self.next = $el.find('.owl-item').eq(e.item.index).children().attr('data-index');
            $el.find('.show-content').removeClass('show-content');
            if (self.prev != self.next) {
                $el.find('.show-content').removeClass('show-content');
                /* clear all animations that are running. */
                if ($el.hasClass("animation-slider")) {
                    for (var i = 0; i < self.timers.length; i++) {
                        Donald.deleteTimeout(self.timers[i]);
                    }
                    self.timers = [];
                }
                $el.find('.owl-item.active .slide-animate').each(function () {
                    var $animation_item = $(this),
                        settings = $.extend(true, {}, Donald.animationOptions, Donald.parseOptions($animation_item.data('animation-options'))),
                        duration = settings.duration,
                        delay = settings.delay,
                        aniName = settings.name;

                    $animation_item.css('animation-duration', duration);
                    $animation_item.css('animation-delay', delay);
                    $animation_item.addClass(aniName);

                    if ($animation_item.hasClass('maskLeft')) {
                        $animation_item.css('width', 'fit-content');
                        var width = $animation_item.width();
                        $animation_item.css('width', 0).css(
                            'transition',
                            'width ' + (duration ? duration : '0.75s') + ' linear ' + (delay ? delay : '0s'));
                        $animation_item.css('width', width);
                    }
                    //$this.addClass('show-content');
                    duration = duration ? duration : '0.75s';
                    var temp = Donald.requestTimeout(function () {
                        $animation_item.addClass('show-content');
                        self.timers.splice(self.timers.indexOf(temp), 1)
                    }, (delay ? Number((delay).slice(0, -1)) * 1000 + Number((duration).slice(0, -1)) * 500 : Number((duration).slice(0, -1)) * 500));
                    self.timers.push(temp);
                });
            } else {
                $el.find('.owl-item').eq(e.item.index).find('.slide-animate').addClass('show-content');
            }
            // $(this).find('.owl-item').eq(e.item.index + 1).find('.slide-animate').removeClass('show-content');
            // $(this).find('.owl-item').eq(e.item.index - 1).find('.slide-animate').removeClass('show-content');

            // $(this).find('.owl-item').eq(e.item.index - e.item.count).find('.slide-animate').addClass('show-content');
            // $(this).find('.owl-item').eq(e.item.index + e.item.count).find('.slide-animate').addClass('show-content');
            self.translateFlag = 0;
        }
        $(window).trigger('appear.check');
    }

    // Public Properties

    Slider.defaults = {
        responsiveClass: true,
        navText: ['<i class="d-icon-angle-left">', '<i class="d-icon-angle-right">'],
        checkVisible: false,
        items: 1,
        smartSpeed: navigator.userAgent.indexOf("Edge") > -1 ? 200 : 700,
        autoplaySpeed: navigator.userAgent.indexOf("Edge") > -1 ? 200 : 1000,
        autoplayTimeout: 10000
    }

    Slider.zoomImage = function () {
        Donald.zoomImage(this.$element);
    }

    Slider.zoomImageRefresh = function () {
        this.$element.find('img').each(function () {
            var $this = $(this);

            if ($.fn.elevateZoom) {
                var elevateZoom = $this.data('elevateZoom');
                if (typeof elevateZoom !== 'undefined') {
                    elevateZoom.refresh();
                } else {
                    Donald.zoomImageOptions.zoomContainer = $this.parent();
                    $this.elevateZoom(Donald.zoomImageOptions);
                }
            }
        });
    }

    Slider.presets = {
        'intro-slider': {
            animateIn: 'fadeIn',
            animateOut: 'fadeOut'
        },
        'product-single-carousel': {
            dots: false,
            nav: true,
            onInitialized: Slider.zoomImage,
            onRefreshed: Slider.zoomImageRefresh
        }
    }

    Slider.addPreset = function (className, options) {
        this.presets[className] = options;
        return this;
    }

    Slider.prototype.init = function ($el, options) {
        this.timers = [];
        this.translateFlag = 0;
        this.prev = 1;
        this.next = 1;

        var self = this,
            classes = $el.attr('class').split(' '),
            settings = $.extend(true, {}, Slider.defaults);

        // extend preset options
        classes.forEach(function (className) {
            var preset = Slider.presets[className];
            preset && $.extend(true, settings, preset);
        });

        // extend user options
        $.extend(true, settings, Donald.parseOptions($el.attr('data-owl-options')), options);

        onSliderInitialized = onSliderInitialized.bind(this);
        onSliderTranslate = onSliderTranslate.bind(this);
        onSliderTranslated = onSliderTranslated.bind(this);

        // init
        $el.on('initialize.owl.carousel', onInitialize)
            .on('initialized.owl.carousel', onInitialized)
            .on('translated.owl.carousel', onSliderTranslated);

        // if animation slider
        $el.hasClass('animation-slider') &&
            $el.on('initialized.owl.carousel', onSliderInitialized)
                .on('resized.owl.carousel', onSliderResized)
                .on('translate.owl.carousel', onSliderTranslate)
                .on('translated.owl.carousel', onSliderTranslated);

        $el.owlCarousel(settings);
    }

    Donald.slider = function (selector, options) {
        Donald.$(selector).each(function () {
            var $this = $(this);

            Donald.call(function () {
                new Slider($this, options);
            });
        });
    }
})(jQuery);

