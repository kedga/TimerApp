import TimeRemaining from "./subcomponents/TimeRemaining";
import TimerTitle from "./subcomponents/TimerTitle";

type timerProps = {
    name: string;
    timeLimit: string;
    bgColor: string;
    askDelete?: boolean;
};

export default function Timer({ name, timeLimit }: timerProps) {
    return (
        <div className="group timer-wrapper pb-0 cursor-pointer bg-running-500">
            <div className="w-full opacity-100 group-hover:fade-opacity fade">
                <TimerTitle name={name} timeLimit={timeLimit} />
            </div>
            <div className="h-full w-full relative -translate-y-2">
                                {/* h-full flex items-center justify-center group-hover:scale-75 fade group-hover:-translate-x-12 opacity-100 group-hover:fade-opacity */}
                                {/* h-full translate-y-8 group-hover:scale-75 fade group-hover:-translate-x-12 opacity-100 group-hover:fade-opacity */}
                <div className="h-full group-hover:scale-75 fade group-hover:-translate-x-12 opacity-100 group-hover:fade-opacity">
                    <TimeRemaining s={50} />
                </div>
                <div className="absolute top-1/2 right-6 -translate-y-1/2 opacity-0 group-hover:opacity-100 group-hover:scale-150 fade drop-shadow-md">
                    <i className="fa-solid fa-arrow-rotate-left text-5xl"></i>
                </div>
            </div>
        </div>
    );
}
