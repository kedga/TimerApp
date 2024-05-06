import TimerTitle from "./subcomponents/TimerTitle";

type timerProps = {
    name: string;
    timeLimit: string;
    bgColor: string;
    askDelete?: boolean;
};

export default function Timer({ }: timerProps) {
    return (
        <div className="bg-neutral-500 timer-wrapper">
            <TimerTitle name={"Ramen"} timeLimit={"3 min"} />
            <div className="timer-content-wrapper text-6xl font-semibold">
                <button className="big-round-button font-bold hover:bg-neutral-400">
                    Y
                </button>
                <p className="select-none">/</p>
                <button className="big-round-button font-bold hover:bg-neutral-400">
                    N
                </button>
            </div>
        </div>
    );
}
