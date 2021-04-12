/**
 * Donald Dependent Plugins
 */

(function () {
    var checks = [],
        timerId = false,
        one,
        a, b, o, x, y, ax, ay;

    var checkAll = function () {
        for (var i = checks.length; i--;) {
            one = checks[i];
            a = window.pageXOffset;
            b = window.pageYOffset;
            o = one.el.getBoundingClientRect();
            x = o.left + a;
            y = o.top + b;
            ax = one.options.accX;
            ay = one.options.accY;

            if (y + o.height + ay >= b &&
                y <= b + window.innerHeight + ay &&
                x + o.width + ax >= a &&
                x <= a + window.innerWidth + ax) {

                one.fn.call(one.el, one.data);
                checks.splice(i, 1);
            }
        }
    };

    Donald.appear = function (el, fn, options) {
        var settings = {
            data: undefined,
            accX: 0,
            accY: 0
        };

        if (options) {
            options.data && (settings.data = options.data);
            options.accX && (settings.accX = options.accX);
            options.accY && (settings.accY = options.accY);
        }

        checks.push({ el: el, fn: fn, options: settings });
        if (!timerId) {
            timerId = Donald.requestTimeout(checkAll, 100);
        }
    }

    window.addEventListener('scroll', checkAll, { passive: true });
    window.addEventListener('resize', checkAll, { passive: true });
    $(window).on('appear.check', checkAll);
})();

(function ($) {

    Donald.zoomImageOptions = {
        responsive: true,
        zoomWindowFadeIn: 750,
        zoomWindowFadeOut: 500,
        borderSize: 0,
        zoomType: 'inner',
        cursor: 'crosshair'
    };

    Donald.zoomImageObjects = [], // issue
        /**
         * @function zoomImage
         * 
         * @requires elevateZoom
         * @param {jQuery} $el
         */
        Donald.zoomImage = function ($el) {
            if ($.fn.elevateZoom && $el) {
                (('string' === typeof $el) ? $($el) : $el)
                    .find('img').each(function () {
                        var $this = $(this);
                        Donald.zoomImageOptions.zoomContainer = $this.parent();
                        $this.elevateZoom(Donald.zoomImageOptions);
                        Donald.zoomImageObjects.push($this);
                    });
            }
        }
    Donald.zoomImageOnResize = function () {
        Donald.zoomImageObjects.forEach(function ($img) {
            $img.each(function () {
                var elevateZoom = $(this).data('elevateZoom');
                elevateZoom && elevateZoom.refresh();
            })
        });
    }


    /**
     * @function countTo
     * 
     * @requires jQuery.countTo
     * @param {string} selector
     */
    Donald.countTo = function (selector) {
        if ($.fn.countTo) {
            Donald.$(selector).each(function () {
                Donald.appear(this, function () {
                    var $this = $(this);
                    setTimeout(function () {
                        $this.countTo({
                            onComplete: function () {
                                $this.addClass('complete');
                            }
                        });
                    }, 300);
                })
            });
        }
    }


    /**
     * @function countdown
     *
     * @requires countdown
     * @param {string} selector
     */
    Donald.countdown = function (selector) {
        if ($.fn.countdown) {
            Donald.$(selector).each(function () {
                var $this = $(this),
                    untilDate = $this.data('until'),
                    compact = $this.data('compact'),
                    dateFormat = (!$this.data('format')) ? 'DHMS' : $this.data('format'),
                    newLabels = (!$this.data('labels-short')) ?
                        ['Years', 'Months', 'Weeks', 'Days', 'Hours', 'Minutes', 'Seconds'] :
                        ['Years', 'Months', 'Weeks', 'Days', 'Hours', 'Mins', 'Secs'],
                    newLabels1 = (!$this.data('labels-short')) ?
                        ['Year', 'Month', 'Week', 'Day', 'Hour', 'Minute', 'Second'] :
                        ['Year', 'Month', 'Week', 'Day', 'Hour', 'Min', 'Sec'];

                var newDate;

                // Split and created again for ie and edge
                if (!$this.data('relative')) {
                    var untilDateArr = untilDate.split(", "), // data-until 2019, 10, 8 - yy,mm,dd
                        newDate = new Date(untilDateArr[0], untilDateArr[1] - 1, untilDateArr[2]);
                } else {
                    newDate = untilDate;
                }

                $this.countdown({
                    until: newDate,
                    format: dateFormat,
                    padZeroes: true,
                    compact: compact,
                    compactLabels: [' y', ' m', ' w', ' days, '],
                    timeSeparator: ' : ',
                    labels: newLabels,
                    labels1: newLabels1
                });
            });
        }
    }


    /**
     * @function priceSlider
     * Create price slider
     * 
     * @requires noUiSlider
     * @param {string} selector
     * @param {object} option
     */
    Donald.priceSlider = function (selector, option) {
        if (typeof noUiSlider === 'object') {
            Donald.$(selector).each(function () {
                var self = this;

                noUiSlider.create(self, $.extend(true, {
                    start: [18, 35],
                    connect: true,
                    step: 1,
                    range: {
                        min: 18,
                        max: 35
                    }
                }, option));

                // Update Price Range
                self.noUiSlider.on('update', function (values, handle) {
                    var values = values.map(function (value) {
                        return '$' + parseInt(value);
                    })
                    $(self).parent().find('.filter-price-range').text(values.join(' - '));
                });
            });
        }
    }


    Donald.isotopeOptions = {
        itemsSelector: '.grid-item',
        layoutMode: 'masonry',
        percentPosition: true,
        masonry: {
            columnWidth: '.grid-space'
        }
    }
    /**
     * @function isotopes
     *
     * @requires isotope,imagesLoaded
     * @param {string} selector,
     * @param {object} options
     */
    Donald.isotopes = function (selector, options) {
        if (typeof imagesLoaded === 'function' && $.fn.isotope) {
            var self = this;

            Donald.$(selector).each(function () {
                var $this = $(this),
                    settings = $.extend(true, {},
                        self.isotopeOptions,
                        Donald.parseOptions($this.attr('data-grid-options')),
                        options ? options : {}
                    );
                $this.isotope(settings);
            });
        }
    }

    /**
     * @function initNavFilter
     *
     * @requires isotope
     * @param {string} selector
     */
    Donald.initNavFilter = function (selector) {
        if ($.fn.isotope) {
            Donald.$(selector).on('click', function (e) {
                var $this = $(this),
                    filterValue = $this.attr('data-filter'),
                    filterTarget = $this.parent().parent().attr('data-target');
                (filterTarget ? $(filterTarget) : $('.grid')).isotope({ filter: filterValue });
                $this.parent().siblings().children().removeClass('active');
                $this.addClass('active');
                e.preventDefault();
            });
        }
    }

    /**
     * @function parallax
     * Initialize Parallax Background
     * @requires themePluginParallax
     * @param {string} selector
     */
    Donald.parallax = function (selector, options) {
        if ($.fn.themePluginParallax) {
            Donald.$(selector).each(function () {
                var $this = $(this);
                $this.themePluginParallax(
                    $.extend(true, Donald.parseOptions($this.attr('data-parallax-options')), options)
                );
            });
        }
    }

    /**
     * @function headerToggleSearch
     * Init header toggle search.
     * @param {string} selector
     */

    Donald.headerToggleSearch = function (selector) {
        var $search = Donald.$(selector);
        $search.find('.form-control').on('focusin', function (e) {
            $search.addClass('show');
        });
        $search.find('.form-control').on('focusout', function (e) {
            $search.removeClass('show');
        });
    }


    Donald.stickyHeaderOptions = {
        activeScreenWidth: Donald.desktop_width
    }
    /**
     * @function stickyHeader
     * Init sticky header
     * @param {string} selector
     */
    Donald.stickyHeader = function (selector) {
        var $stickyHeader = Donald.$(selector);
        if ($stickyHeader.length == 0) return;

        var height, top, isWrapped = false;

        // define wrap function
        var stickyHeaderWrap = function () {
            height = $stickyHeader[0].offsetHeight;
            top = $stickyHeader.offset().top + height;

            // if sticky header has category dropdown, increase top
            if ($stickyHeader.hasClass('has-dropdown')) {
                var $box = $stickyHeader.find('.category-dropdown .dropdown-box');

                if ($box.length) {
                    top += $stickyHeader.find('.category-dropdown .dropdown-box')[0].offsetHeight;
                }
            }

            // wrap sticky header
            if (!isWrapped && window.innerWidth >= Donald.stickyHeaderOptions.activeScreenWidth) {
                isWrapped = true;
                $stickyHeader.wrap('<div class="sticky-wrapper" style="height:' + height + 'px"></div>');
            }

            Donald.$window.off('resize', stickyHeaderWrap);
        };

        // define refresh function
        var stickyHeaderRefresh = function () {
            var isFixed = window.innerWidth >= Donald.stickyHeaderOptions.activeScreenWidth && window.pageYOffset >= top;

            // fix or unfix
            if (isFixed) {
                $stickyHeader[0].classList.add('fixed');
                document.body.classList.add('sticky-header-active');
            } else {
                $stickyHeader[0].classList.remove('fixed');
                document.body.classList.remove('sticky-header-active');
            }
        };

        // register events
        window.addEventListener('scroll', stickyHeaderRefresh, { passive: true });
        Donald.$window.on('resize', stickyHeaderWrap);
        Donald.$window.on('resize', stickyHeaderRefresh);

        // init
        Donald.call(stickyHeaderWrap, 500);
        Donald.call(stickyHeaderRefresh, 500);
    }

    Donald.stickyDefaultOptions = {
        minWidth: Donald.desktop_width,
        maxWidth: 20000,
        top: false,
        hide: false, // hide when it is not sticky.
        max_index: 1060 // maximum z-index of sticky contents
    }
    /**
     * @function stickyContent
     * Init Sticky Content
     * @param {string, Object} selector
     * @param {Object} settings
     */
    Donald.stickyContent = function (selector, settings) {
        var $stickyContents = Donald.$(selector),
            offsetTop = 0,
            offsetBottom = 0,
            options = $.extend({}, Donald.stickyDefaultOptions, settings);

        if (0 == $stickyContents.length) return;

        var setTopOffset = function ($item) {
            var offset = 0,
                index = 0;
            $('.sticky-content.fixed.fix-top').each(function () {
                offset += $(this)[0].offsetHeight;
                index++;
            });
            $item.data('offset-top', offset);
            $item.data('z-index', options.max_index - index);
        }

        var setBottomOffset = function ($item) {
            var offset = 0,
                index = 0;
            $('.sticky-content.fixed.fix-bottom').each(function () {
                offset += $(this)[0].offsetHeight;
                index++;
            });
            $item.data('offset-bottom', offset);
            $item.data('z-index', options.max_index - index);
        }

        var wrapStickyContent = function ($item, height) {
            if (window.innerWidth >= options.minWidth && window.innerWidth <= options.maxWidth) {
                $item.wrap('<div class="sticky-content-wrapper"></div>');
                $item.parent().css('height', height + 'px');
                $item.data('is-wrap', true);
            }
        }

        var initStickyContent = function () {
            $stickyContents.each(function (index) {
                var $item = $(this);
                if (!$item.data('is-wrap')) {
                    var height = $item.removeClass('fixed').outerHeight(true), top;
                    top = $item.offset().top + height;

                    // if sticky header has category dropdown, increase top
                    if ($item.hasClass('has-dropdown')) {
                        var $box = $item.find('.category-dropdown .dropdown-box');

                        if ($box.length) {
                            top += $box[0].offsetHeight;
                        }
                    }

                    $item.data('top', top);
                    wrapStickyContent($item, height);
                } else {
                    if (window.innerWidth < options.minWidth || window.innerWidth >= options.maxWidth) {
                        $item.unwrap('.sticky-content-wrapper');
                        $item.data('is-wrap', false);
                    }
                }
            });
            // Donald.$window.off('resize', initStickyContent);
        }

        var refreshStickyContent = function (e) {
            if (e && !e.isTrusted) return;
            $stickyContents.each(function (index) {
                var $item = $(this);
                if (window.pageYOffset > (false == options.top ? $item.data('top') : options.top) && window.innerWidth >= options.minWidth && window.innerWidth <= options.maxWidth) {
                    if ($item.hasClass('fix-top')) {
                        undefined == $item.data('offset-top') && setTopOffset($item);
                        $item.css('margin-top', $item.data('offset-top') + 'px');
                    } else if ($item.hasClass('fix-bottom')) {
                        undefined == $item.data('offset-bottom') && setBottomOffset($item);
                        $item.css('margin-bottom', $item.data('offset-bottom') + 'px');
                    }
                    $item.css('z-index', $item.data('z-index'));
                    $item.addClass('fixed');
                    options.hide && $item.parent('.sticky-content-wrapper').css('display', '');
                } else {
                    $item.removeClass('fixed');
                    $item.css('margin-top', '');
                    $item.css('margin-bottom', '');
                    options.hide && $item.parent('.sticky-content-wrapper').css('display', 'none');
                }
            });
        }

        Donald.call(initStickyContent, 550);
        Donald.call(refreshStickyContent, 560);

        Donald.call(function () {
            window.addEventListener('scroll', refreshStickyContent, { passive: true });
            Donald.$window.on('resize', initStickyContent);
            Donald.$window.on('resize', refreshStickyContent);
        }, 700);

    }

    /**
     * @function alert
     * Register events for alert
     * @param {string} selector
     */
    Donald.alert = function (selector) {
        Donald.$body.on('click', selector + ' .btn-close', function (e) {
            $(this).closest(selector).fadeOut(function () {
                $(this).remove();
            });
        });
    }


    /**
     * @function accordion
     * Register events for accordion
     * @param {string} selector
     */
    Donald.accordion = function (selector) {
        Donald.$body.on('click', selector, function (e) {
            var $this = $(this),
                $header = $this,
                $body = $this.closest('.card').find($this.attr('href')),
                $parent = $this.closest('.accordion');

            e.preventDefault();

            if (0 === $parent.find(".collapsing").length &&
                0 === $parent.find(".expanding").length) {

                if ($body.hasClass('expanded')) {
                    if (!$parent.hasClass('radio-type'))
                        slideToggle($body);

                } else if ($body.hasClass('collapsed')) {

                    if ($parent.find('.expanded').length > 0) {
                        if (Donald.isIE) {
                            slideToggle($parent.find('.expanded'), function () {
                                slideToggle($body);
                            });

                        } else {
                            slideToggle($parent.find('.expanded'));
                            slideToggle($body);
                        }
                    } else {
                        slideToggle($body);
                    }
                }
            }
        });

        // define slideToggle method
        var slideToggle = function ($wrap, callback) {
            var $header = $wrap.closest('.card').find(selector);

            if ($wrap.hasClass("expanded")) {
                $header
                    .removeClass("collapse")
                    .addClass("expand");
                $wrap
                    .addClass("collapsing")
                    .slideUp(300, function () {
                        $wrap.removeClass("expanded collapsing").addClass("collapsed");
                        callback && callback();
                    })

            } else if ($wrap.hasClass("collapsed")) {
                $header
                    .removeClass("expand")
                    .addClass("collapse");
                $wrap
                    .addClass("expanding")
                    .slideDown(300, function () {
                        $wrap.removeClass("collapsed expanding").addClass("expanded");
                        callback && callback();
                    })
            }
        };
    }


    /**
     * @function tab
     * Register events for tab
     * @param {string} selector
     */
    Donald.tab = function (selector) {

        Donald.$body

            // tab nav link
            .on('click', '.tab .nav-link', function (e) {
                var $this = $(this);
                e.preventDefault();

                if (!$this.hasClass("active")) {
                    var $panel = $($this.attr('href'));
                    $panel.parent().find('.active').removeClass('in active');
                    $panel.addClass('active in');

                    $this.parent().parent().find('.active').removeClass('active');
                    $this.addClass('active');
                }
            })

            // link to tab
            .on('click', '.link-to-tab', function (e) {
                var selector = $(e.currentTarget).attr('href'),
                    $tab = $(selector),
                    $nav = $tab.parent().siblings('.nav');
                e.preventDefault();

                $tab.siblings().removeClass('active in');
                $tab.addClass('active in');
                $nav.find('.nav-link').removeClass('active');
                $nav.find('[href="' + selector + '"]').addClass('active');

                $('html').animate({
                    scrollTop: $tab.offset().top - 150
                });
            });
    }

    /**
     * @function playableVideo
     * 
     * @param {string} selector
     */
    Donald.playableVideo = function (selector) {
        $(selector + ' .video-play').on('click', function (e) {
            var $video = $(this).closest(selector);
            if ($video.hasClass('playing')) {
                $video.removeClass('playing')
                    .addClass('paused')
                    .find('video')[0].pause();
            } else {
                $video.removeClass('paused')
                    .addClass('playing')
                    .find('video')[0].play();
            }
            e.preventDefault();
        });
        $(selector + ' video').on('ended', function () {
            $(this).closest('.post-video').removeClass('playing');
        });
    }


    Donald.animationOptions = {
        name: 'fadeIn',
        duration: '1.2s',
        delay: '.2s'
    };
    /**
     * @function appearAnimate
     * 
     * @param {string} selector
     */
    Donald.appearAnimate = function (selector) {
        Donald.$(selector).each(function () {
            var el = this;
            Donald.appear(el, function () {
                if (el.classList.contains('appear-animate')) {
                    var settings = $.extend({}, Donald.animationOptions, Donald.parseOptions(el.getAttribute('data-animation-options')));

                    Donald.call(function () {
                        el.style['animation-duration'] = settings.duration;
                        el.style['animation-delay'] = settings.delay;
                        el.classList.add(settings.name);

                        setTimeout(
                            function () {
                                el.classList.add('appear-animation-visible');
                            },
                            settings.delay ? Number(settings.delay.slice(0, -1)) * 1000 + Number(settings.duration.slice(0, -1)) * 500 : Number(settings.duration.slice(0, -1)) * 500
                        );
                    });
                }
            });
        });
    }

    /**
     * @function stickySidebar
     * 
     * @requires themeSticky
     * @param {string} selector
     */
    Donald.stickySidebar = function (selector) {
        if ($.fn.themeSticky) {
            Donald.$(selector).each(function () {
                var $this = $(this);
                $this.themeSticky($.extend(Donald.stickySidebarOptions, Donald.parseOptions($this.attr('data-sticky-options'))));
                $this.trigger('recalc.pin');
            });
        }
    }
    Donald.recalcAll = function (selector) {
        if ($.fn.themeSticky) {
            Donald.$(selector).each(function () {
                $(this).trigger('recalc.pin');
            });
        }
    }
    Donald.stickySidebarOptions = {
        autoInit: true,
        minWidth: 991,
        containerSelector: '.sticky-sidebar-wrapper',
        autoFit: true,
        activeClass: 'sticky-sidebar-fixed',
        top: 93,
        bottom: 0,
    };



    /**
     * @function ratingTooltip
     * 
     * @param {HTMLElement} root
     * 
     * Find all .ratings-full from root, and initialize tooltip.
     */
    Donald.ratingTooltip = function (root) {
        var els = Donald.byClass('ratings-full', root ? root : document.body),
            len = els.length;

        var ratingHandler = function () {
            var res = this.firstElementChild.clientWidth / this.clientWidth * 5;
            this.lastElementChild.innerText = res ? res.toFixed(2) : res;
        }
        for (var i = 0; i < len; ++i) {
            els[i].addEventListener('mouseover', ratingHandler);
            els[i].addEventListener('touchstart', ratingHandler);
        }
    }


    /**
     * @function initPopups
     */
    Donald.initPopups = function () {

        // Register Login Popup
        $('a.login, .login-link').on('click', function (e) {
            e.preventDefault();
            Donald.popup({
                items: {
                    src: $(this).attr('href')
                }
            }, 'login');
        });

        // Register "Register" Popup
        $('.register-link').on('click', function (e) {
            e.preventDefault();
            Donald.popup({
                items: {
                    src: $(this).attr('href')
                },
                callbacks: {
                    ajaxContentAdded: function () {
                        this.wrap.find('[href="#register"]').click();
                    }
                }
            }, 'login');
        });

        // Register "Play Video" Popup
        $('.btn-iframe').on('click', function (e) {
            e.preventDefault();
            Donald.popup({
                items: {
                    src: $(this).attr('href')
                }
            }, 'video');
        });

        // Open newsletter Popup after 7.5s in home pages
        if (Donald.$body.hasClass('home') && Donald.getCookie('hideNewsletterPopup') !== 'true') {
            setTimeout(function () {
                Donald.popup({
                    items: {
                        src: 'ajax/newsletter.html'
                    },
                    type: 'ajax',
                    tLoading: '',
                    mainClass: 'mfp-newsletter mfp-flip-popup',
                    callbacks: {
                        beforeClose: function () {
                            // if "do not show" is checked
                            $('#hide-newsletter-popup')[0].checked && Donald.setCookie('hideNewsletterPopup', true, 7);
                        }
                    },
                });
            }, 7500);
        }
    }


    Donald.initPurchasedMinipopup = function () {
        if (Donald.byClass('product-single').length || Donald.byClass('main-content').length) {
            setInterval(function () {
                Donald.minipopup.open({
                    message: 'Someone just purchased below.',
                    productClass: ' product-list-sm',
                    name: 'Daisy Bag Sonia by Sonia Rykiel',
                    nameLink: 'product.html',
                    imageSrc: 'images/cart/product-1.jpg',
                    price: '$199',
                    rating: 5
                }, function ($box) {
                    Donald.ratingTooltip($box[0]);
                });
            }, 60000);
        }
    }

    Donald.initScrollTopButton = function () {
        // register scroll top button
        var domScrollTop = Donald.byId('scroll-top');

        domScrollTop.addEventListener('click', function (e) {
            $('html, body').animate({ scrollTop: 0 }, 600);
            e.preventDefault();
        });

        var refreshScrollTop = function () {
            if (window.pageYOffset > 400) {
                domScrollTop.classList.add('show');
            } else {
                domScrollTop.classList.remove('show');
            }
        }

        Donald.call(refreshScrollTop, 500);
        window.addEventListener('scroll', refreshScrollTop, { passive: true });
    }


    /**
     * @function requestTimeout
     * @param {function} fn
     * @param {number} delay
     */
    Donald.requestTimeout = function (fn, delay) {
        var handler = window.requestAnimationFrame || window.webkitRequestAnimationFrame || window.mozRequestAnimationFrame;
        if (!handler) {
            return setTimeout(fn, delay);
        }
        var start, rt = new Object();

        function loop(timestamp) {
            if (!start) {
                start = timestamp;
            }
            var progress = timestamp - start;
            progress >= delay ? fn() : rt.val = handler(loop);
        };

        rt.val = handler(loop);
        return rt;
    },

        /**
         * @function requestInterval
         * @param {function} fn
         * @param {number} step
         * @param {number} timeOut
         */
        Donald.requestInterval = function (fn, step, timeOut) {
            var handler = window.requestAnimationFrame || window.webkitRequestAnimationFrame || window.mozRequestAnimationFrame;
            if (!handler) {
                if (!timeOut)
                    return setTimeout(fn, timeOut);
                else
                    return setInterval(fn, step);
            }
            var start, last, rt = new Object();
            function loop(timestamp) {
                if (!start) {
                    start = last = timestamp;
                }
                var progress = timestamp - start;
                var delta = timestamp - last;
                if (!timeOut || progress < timeOut) {
                    if (delta > step) {
                        fn();
                        rt.val = handler(loop);
                        last = timestamp;
                    } else {
                        rt.val = handler(loop);
                    }
                } else {
                    fn();
                }
            };
            rt.val = handler(loop);
            return rt;
        },

        /**
         * @function deleteTimeout
         * @param {number} timerID
         */
        Donald.deleteTimeout = function (timerID) {
            if (!timerID) {
                return;
            }
            var handler = window.cancelAnimationFrame || window.webkitCancelAnimationFrame || window.mozCancelAnimationFrame;
            if (!handler) {
                return clearTimeout(timerID);
            }
            if (timerID.val) {
                return handler(timerID.val);
            }
        }
})(jQuery);


(function ($) {

    // Private Properties

    var showMobileMenu = function () {
        Donald.$body.addClass('mmenu-active');
    };
    var hideMobileMenu = function () {
        Donald.$body.removeClass('mmenu-active');
    };

    /**
     * @function initMenu
     */
    var Menu = {
        init: function () {
            this.initMenu();
            this.initMobileMenu();
            this.initFilterMenu();
            this.initCategoryMenu();
            this.initCollapsibleWidget();
        },
        initMenu: function () {
            // setup menu
            $('.menu li').each(function () {
                if (this.lastElementChild && (
                    this.lastElementChild.tagName === 'UL' ||
                    this.lastElementChild.classList.contains('megamenu'))
                ) {
                    this.classList.add('submenu');
                }
            });

            // calc megamenu position
            Donald.$window.on('resize', function () {
                $('.main-nav .megamenu').each(function () {
                    var $this = $(this),
                        left = $this.offset().left,
                        outerWidth = $this.outerWidth(),
                        offset = (left + outerWidth) - (window.innerWidth - 20);
                    if (offset > 0 && left > 20) {
                        $this.css('margin-left', -offset);
                    }
                });
            })
        },
        initMobileMenu: function () {
            $('.mobile-menu li, .toggle-menu li').each(function () {
                if (this.lastElementChild && (
                    this.lastElementChild.tagName === 'UL' ||
                    this.lastElementChild.classList.contains('megamenu'))
                ) {
                    var span = document.createElement('span');
                    span.className = "toggle-btn";
                    this.firstElementChild.appendChild(span);
                    // this.firstElementChild.insertAdjacentHTML('beforeend', '<span class="toggle-btn"></span>' );
                }
            });
            $('.mobile-menu-toggle').on('click', showMobileMenu);
            $('.mobile-menu-overlay').on('click', hideMobileMenu);
            $('.mobile-menu-close').on('click', hideMobileMenu);
            Donald.$window.on('resize', hideMobileMenu);
        },
        initFilterMenu: function () {
            $('.search-ul li').each(function () {
                if (this.lastElementChild && this.lastElementChild.tagName === 'UL') {
                    var i = document.createElement('i');
                    i.className = "fas fa-chevron-down";
                    this.classList.add('with-ul');
                    this.firstElementChild.appendChild(i);
                }
            });
            $('.with-ul > a i, .toggle-btn').on('click', function (e) {
                $(this).parent().next().slideToggle(300).parent().toggleClass("show");
                e.preventDefault();
            });
        },
        initCategoryMenu: function () {
            // cat dropdown
            var $menu = $('.category-dropdown');
            if ($menu.length) {
                var $box = $menu.find('.dropdown-box');
                if ($box.length) {
                    var top = $('.main').offset().top + $box[0].offsetHeight;
                    if (window.pageYOffset > top || window.innerWidth < Donald.desktop_width) {
                        $menu.removeClass('show');
                    }
                    window.addEventListener('scroll', function () {
                        if (window.pageYOffset <= top && window.innerWidth >= Donald.desktop_width) {
                            $menu.removeClass('show');
                        }
                    }, { passive: true });
                    $('.category-toggle').on("click", function (e) {
                        e.preventDefault();
                    })
                    $menu.on("mouseover", function (e) {
                        if (window.pageYOffset > top && window.innerWidth >= Donald.desktop_width) {
                            $menu.addClass('show');
                        }
                    })
                    $menu.on("mouseleave", function (e) {
                        if (window.pageYOffset > top && window.innerWidth >= Donald.desktop_width) {
                            $menu.removeClass('show');
                        }
                    })
                }
                if ($menu.hasClass('with-sidebar')) {
                    var sidebar = Donald.byClass('sidebar');
                    if (sidebar.length) {
                        $menu.find('.dropdown-box').css('width', sidebar[0].offsetWidth - 20);

                        // set category menu's width same as sidebar.
                        Donald.$window.on('resize', function () {
                            $menu.find('.dropdown-box').css('width', (sidebar[0].offsetWidth - 20));
                        });
                    }
                }
            }
        },
        initCollapsibleWidget: function () {
            // generate toggle icon
            $('.widget-collapsible .widget-title').each(function () {
                var span = document.createElement('span');
                span.className = 'toggle-btn';
                this.appendChild(span);
            });
            // slideToggle
            $('.widget-collapsible .widget-title').on('click', function (e) {
                var $this = $(this);
                if (!$this.hasClass('sliding')) {
                    var $body = $this.siblings('.widget-body');

                    $this.hasClass("collapsed") || $body.css('display', 'block');

                    $this.addClass("sliding");
                    $body.slideToggle(300, function () {
                        $this.removeClass("sliding");
                    });

                    $this.toggleClass("collapsed");
                }
            });
        }
    }

    Donald.menu = Menu;
})(jQuery);