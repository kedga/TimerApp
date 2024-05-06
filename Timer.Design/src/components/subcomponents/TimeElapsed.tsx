import Time from "./Time";

export const textSizes: { [key: number]: string } = {
    1: "text-[1rem]",
    1.5: "text-[1.5rem]",
    2: "text-[2rem]",
    2.5: "text-[2.5rem]",
    3: "text-[3rem]",
    3.5: "text-[3.5rem]",
    4: "text-[4rem]",
    4.5: "text-[4.5rem]",
    5: "text-[5rem]",
    5.5: "text-[5.5rem]",
    6: "text-[6rem]",
    6.5: "text-[6.5rem]",
    7: "text-[7rem]",
};

export default function TimeElapsed({ s, negative = false }: { s: number, negative: boolean }) {
    const textSize = s > 3599 ? 3 : s > 59 ? 4 : 5;

    return (
        <div className="h-full flex items-center leading-[0]">
            <div className="w-full flex gap-4 justify-center items-baseline">
                <p className={"font-bold text-nowrap " + textSizes[textSize]}>
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
        </div>
    );
}
