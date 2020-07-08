async function main() {
    const webdriver = require('selenium-webdriver');

    const instagramUrl = 'https://www.instagram.com'
    const targetInstagramUrl = 'https://www.instagram.com/p/CCUKG7AHltl/'
    const capabilities = {
        platform: 'windows 10',
        browserName: 'chrome',
        network: true,
        visual: true,
        console: true,
        video: true,
        build: 'NodeJS build' // name of the build
    }
    const words = ['Meu', 'aniversário', 'é', 'dia', '20']
    const driver = await new webdriver.Builder()
        .withCapabilities(capabilities)
        .build();

    await driver.get(instagramUrl);

    const until = webdriver.until;

    const userNameField = await driver.wait(until.elementLocated(webdriver.By.name('username')), 5000);
    const passwordField = await driver.wait(until.elementLocated(webdriver.By.name('password')), 5000);
    const loginButton = await driver.wait(until.elementLocated(webdriver.By.xpath("//button[@type='submit']")), 10000);

    await userNameField.sendKeys('');
    await passwordField.sendKeys('')
    await loginButton.click();

    await driver.sleep(10000)


    let count = 0;

    while (true) {
        await driver.get(targetInstagramUrl);

        if (count >= words.length) {
            count = 0;
        }

        await driver.sleep(5000)
        const inputComment = await driver.findElement(webdriver.By.className("Ypffh"))

        if (inputComment == null || !inputComment.Displayed || !inputComment.Enabled) {
            continue;
        }
        inputComment.click();

        await driver.sleep(2000)
        driver.findElement(webdriver.By.className("Ypffh")).sendKeys(words[count]);
        await driver.sleep(2000)
        await driver.findElement(webdriver.By.xpath("//button[@type='submit']")).click();
        count++;
        await driver.sleep(61000)
    }
}

(async () => {
    try {
        var text = await main();
        console.log(text);
    } catch (e) {
        console.log(e);
    }
})();