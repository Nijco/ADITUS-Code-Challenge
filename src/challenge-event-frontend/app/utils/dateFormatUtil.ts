export function formatDate(dateString: string, includeTime = false, locale: string = 'de-DE'): string {
    let date: Date;
    if (typeof (dateString) !== 'string') {
        return '';
    }
    date = new Date(dateString);

    let format: Intl.DateTimeFormatOptions = {
        year: 'numeric',
        month: 'short',
        day: 'numeric',
        hour: includeTime ? 'numeric' : undefined,
        minute: includeTime ? 'numeric' : undefined,
    };

    return new Intl.DateTimeFormat(locale, format).format(date);
}