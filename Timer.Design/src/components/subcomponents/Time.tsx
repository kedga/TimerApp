import { textSizes } from "./TimeRemaining";

export default function Time({
    number,
    string,
    textSize,
}: {
    number: number;
    string: string;
    textSize: number;
}) {
    return (
        <>
            <span className={"font-sans " + textSizes[textSize]}>{number}</span>
            <span className={"font-normal font-sans " + textSizes[textSize - 2]}>{string}</span>
        </>
    );
}
