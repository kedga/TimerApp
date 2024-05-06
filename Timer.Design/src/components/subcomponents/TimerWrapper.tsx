import { ReactNode } from "react";

export default function TimerWrapper({
    color,
    children,
}: {
    color: string;
    children: ReactNode;
}) {
    return (
        <div
            className={
                "h-48 rounded-3xl flex flex-col items-center overflow-hidden shadow-md p-6 text-white " +
                color
            }>
            {children}
        </div>
    );
}
