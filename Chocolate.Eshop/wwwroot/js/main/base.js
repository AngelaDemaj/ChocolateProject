/**
 * Donald Main JavaScript File
 */
'use strict';

/**
 * Donald Object
 */
window.Donald = {};

/**
 * Donald Base
 */
(function ($) {

    /**
     * Get Scrollbar's Width
     * @return {number} width
     */
    Donald.getScrollbarWidth = function () {
        return window.innerWidth - document.body.clientWidth;
    }

    // Properties & Status
    Donald.$window = $(window);
    Donald.$body = $(document.body);
    Donald.status = '';
    // Donald.desktop_width = 992 - Donald.getScrollbarWidth();
    Donald.desktop_width = 992;

    // Detect Internet Explorer
    Donald.isIE = navigator.userAgent.indexOf("Trident") >= 0;
    // Detect Edge
    Donald.isEdge = navigator.userAgent.indexOf("Edge") >= 0;
    // Detect Mobile
    Donald.isMobile = /Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent);

    /**
     * Make a macro task
     * 
     * @param {function} fn
     * @param {number} delay
     */
    Donald.call = function (fn, delay) {
        setTimeout(fn, delay);
    }

    /**
     * Parse options string to object
     * @param {string} options
     * @return {object} options
     */
    Donald.parseOptions = function (options) {
        return 'string' == typeof options ?
            JSON.parse(options.replace(/'/g, '"').replace(';', '')) :
            {};
    }

    /**
     * Parse html template with variables.
     * @param {string} template
     * @param {object} vars
     * @return {string} parsed template
     */
    Donald.parseTemplate = function (template, vars) {
        return template.replace(/\{\{(\w+)\}\}/g, function () {
            return vars[arguments[1]];
        });
    }

    /**
     * Get dom element by id
     * @param {string} id
     * @return {HTMLElement} element
     */
    Donald.byId = function (id) {
        return document.getElementById(id);
    }

    /**
     * Get dom elements by tagName
     * @param {string} tagName
     * @param {HTMLElement} element this can be omitted.
     * @return {HTMLCollection}
     */
    Donald.byTag = function (tagName, element) {
        return element ?
            element.getElementsByTagName(tagName) :
            document.getElementsByTagName(tagName);
    }

    /**
     * Get dom elements by className
     * @param {string} className
     * @param {HTMLElement} element this can be omitted.
     * @return {HTMLCollection}
     */
    Donald.byClass = function (className, element) {
        return element ?
            element.getElementsByClassName(className) :
            document.getElementsByClassName(className);
    }

    /**
     * Set cookie
     * @param {string} name Cookie name
     * @param {string} value Cookie value
     * @param {number} exdays Expire period
     */
    Donald.setCookie = function (name, value, exdays) {
        var date = new Date();
        date.setTime(date.getTime() + (exdays * 24 * 60 * 60 * 1000));
        document.cookie = name + "=" + value + ";expires=" + date.toUTCString() + ";path=/";
    }

    /**
     * Get cookie
     * @param {string} name Cookie name
     * @return {string} Cookie value
     */
    Donald.getCookie = function (name) {
        var n = name + "=";
        var ca = document.cookie.split(';');
        for (var i = 0; i < ca.length; ++i) {
            var c = ca[i];
            while (c.charAt(0) == ' ') {
                c = c.substring(1);
            }
            if (c.indexOf(n) == 0) {
                return c.substring(n.length, c.length);
            }
        }
        return "";
    }

    /**
     * Get jQuery object
     * @param {string|jQuery} selector
     * @return {jQuery|Object} jQuery Object or {each: $.noop}
     */
    Donald.$ = function (selector) {
        if (selector instanceof jQuery) {
            return selector;
        }
        return $(selector);
    }
})(jQuery);
