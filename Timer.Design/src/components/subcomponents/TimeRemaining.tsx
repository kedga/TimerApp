import Time from "./Time";

export const textSizes: { [key: number]: string } = {
    1: "text-[2.5rem]",
    1.5: "text-[2.75rem]",
    2: "text-[3rem]",
    2.5: "text-[3.25rem]",
    3: "text-[3.5rem]",
    3.5: "text-[3.75rem]",
    4: "text-[4rem]",
    4.5: "text-[4.5rem]",
    5: "text-[5rem]",
    5.5: "text-[5.5rem]",
    6: "text-[6rem]",
    6.5: "text-[6.5rem]",
    7: "text-[7rem]",
};

export default function TimeRemaining({
    s,
    negative = false,
}: {
    s: number;
    negative?: boolean;
}) {
    const textSize = s > 3599 ? 4 : s > 59 ? 6 : 7;

    return (
        <div className="w-full h-full flex gap-4 justify-center items-center">
            <p className={"leading-[0] font-bold text-nowrap " + textSizes[textSize]}>
                {negative && <span className="font-medium">-</span>}
                {s > 3599 && (
                    <Time
                        number={Math.floor(s / 3600)}
                        string={"h "}
                        textSize={textSize}
                    />
                )}
                {s > 59 && (
                    <Time
                        number={Math.floor(s / 60) % 60}
                        string={"m "}
                        textSize={textSize}
                    />
                )}
                <Time number={s % 60} string={"s"} textSize={textSize} />
            </p>
        </div>
    );
}
