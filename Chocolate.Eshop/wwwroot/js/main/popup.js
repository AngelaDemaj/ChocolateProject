/**
 * Donald Plugin - Popup
 * 
 * @requires magnificPopup
 * @instance multiple
 */


function Popup(options, preset) {
    return this.init(options, preset);
}

(function ($) {
    'use strict';

    // Public Properties

    Popup.defaults = {
        removalDelay: 350,
        callbacks: {
            open: function () {
                $('html').css('overflow-y', 'hidden');
                $('body').css('overflow-x', 'visible');
                $('.mfp-wrap').css('overflow', 'hidden auto');
                $('.sticky-header.fixed').css('padding-right', window.innerWidth - document.body.clientWidth);
            },
            close: function () {
                $('html').css('overflow-y', '');
                $('body').css('overflow-x', 'hidden');
                $('.mfp-wrap').css('overflow', '');
                $('.sticky-header.fixed').css('padding-right', '');
            }
        },
    }

    Popup.presets = {
        'login': {
            type: 'ajax',
            mainClass: "mfp-login mfp-fade",
            tLoading: '',
            preloader: false
        },
        'video': {
            type: 'iframe',
            mainClass: "mfp-fade",
            preloader: false,
            closeBtnInside: false
        },
        'quickview': {
            type: 'ajax',
            mainClass: "mfp-product mfp-fade",
            tLoading: '',
            preloader: false
        }
    }

    Popup.prototype.init = function (options, preset) {

        var mpInstance = $.magnificPopup.instance;

        // if something is already opened ( except login popup )

        if (mpInstance.isOpen && mpInstance.content && !mpInstance.content.hasClass('login-popup')) {

            // close current
            mpInstance.close();

            // and open new after a moment

            setTimeout(function () {
                $.magnificPopup.open(
                    $.extend(true, {},
                        Popup.defaults,
                        preset ? Popup.presets[preset] : {},
                        options
                    )
                );
            }, 500);

        } else {

            // if nothing is opened, open new

            $.magnificPopup.open(
                $.extend(true, {},
                    Popup.defaults,
                    preset ? Popup.presets[preset] : {},
                    options
                )
            );
        }
    }

    Donald.popup = function (options, preset) {
        return new Popup(options, preset);
    }
})(jQuery);
